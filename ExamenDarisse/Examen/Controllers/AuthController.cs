using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Examen.Models;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

public class AuthController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost]
    public async Task<IActionResult> Connexion(ConnexionViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.NomUtilisateur, model.MotDePasse, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _httpContextAccessor.HttpContext.Session.SetString("NomUtilisateur", model.NomUtilisateur);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nom d'utilisateur ou mot de passe incorrect.");
            }
        }
        return View(model);
    }

    public async Task<IActionResult> Deconnexion()
    {
        _httpContextAccessor.HttpContext.Session.Remove("NomUtilisateur");

        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> CreerCompte(InscriptionViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = model.NomUtilisateur, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.MotDePasse);
            if (result.Succeeded)
            {
                _httpContextAccessor.HttpContext.Session.SetString("NomUtilisateur", model.NomUtilisateur);

                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(model);
    }
}