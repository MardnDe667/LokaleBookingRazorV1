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
        public string Brugernavn { get; set; }
        public string Password { get; set; }
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
