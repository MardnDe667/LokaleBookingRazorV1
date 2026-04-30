using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LokaleBookingRazor.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Booking ID")]
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }

        public Booking(int id, string navn, string beskrivelse)
        {
            Id = id;
            Navn = navn;
            Beskrivelse = beskrivelse;
        }

        public Booking()
        {
            Id = 0;
            Navn = "";
            Beskrivelse = "";
        }
    }
}
