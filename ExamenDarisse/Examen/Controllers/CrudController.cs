using Microsoft.AspNetCore.Mvc;
using Examen.Models;

namespace Examen.Controllers
{
    public class CrudController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CrudController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Tableau()
        {
            var utilisateurs = _context.Utilisateurs.ToList(); 
            return View(utilisateurs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Utilisateurs.Add(utilisateur);
                _context.SaveChanges();
                return RedirectToAction("Tableau");
            }
            return View(utilisateur);
        }

        public IActionResult Update(int id)
        {
            var utilisateur = _context.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return View(utilisateur);
        }

        [HttpPost]
        public IActionResult Update(int id, Utilisateur utilisateur)
        {
            if (id != utilisateur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(utilisateur);
                _context.SaveChanges();
                return RedirectToAction("Tableau");
            }
            return View(utilisateur);
        }

        public IActionResult Delete(int id)
        {
            var utilisateur = _context.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return View(utilisateur);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var utilisateur = _context.Utilisateurs.Find(id);
            _context.Utilisateurs.Remove(utilisateur);
            _context.SaveChanges();
            return RedirectToAction("Tableau");
        }
    }
}
