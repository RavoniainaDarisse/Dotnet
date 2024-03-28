using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class ConnexionViewModel
    {
        [Required(ErrorMessage = "Le champ Nom d'utilisateur est requis.")]
        public string NomUtilisateur { get; set; }

        [Required(ErrorMessage = "Le champ Mot de passe est requis.")]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }
    }

    public class InscriptionViewModel
    {
        [Required(ErrorMessage = "Le champ Nom d'utilisateur est requis.")]
        public string NomUtilisateur { get; set; }

        [Required(ErrorMessage = "Le champ Email est requis.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse email valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ Mot de passe est requis.")]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }

        [Required(ErrorMessage = "Le champ Confirmation du mot de passe est requis.")]
        [DataType(DataType.Password)]
        [Compare("MotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmerMotDePasse { get; set; }
    }
}
