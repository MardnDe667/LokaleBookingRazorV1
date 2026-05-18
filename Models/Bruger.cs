using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LokaleBookingRazor.Models
{
    public class Bruger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Bruger ID")]
        public int Id { get; set; }

        [Display(Name = "Brugernavn")]
        [Required(ErrorMessage = "Brugernavn skal tilføjes.")]
        [StringLength(100)]
        public string Brugernavn { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password skal tilføjes.")]
        [StringLength(100)]
        public string Password { get; set; }

        [Display(Name = "Rolle")]
        [Required(ErrorMessage = "Rolle skal tilføjes.")]
        public string Rolle { get; set; }

        public Bruger(string brugernavn, string password, string rolle)
        {
            Brugernavn = brugernavn;
            Password = password;
            Rolle = rolle;
        }
        
        public Bruger()
        {
            Id = 0;
            Brugernavn = "";
            Password = "";
            Rolle = "";
        }
    }
}
