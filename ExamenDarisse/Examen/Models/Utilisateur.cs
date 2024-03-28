using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le champ Nom est requis.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est requis.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ Email est requis.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse email valide.")]
        public string Email { get; set; }

    }
}
