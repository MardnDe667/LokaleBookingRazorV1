using System.ComponentModel.DataAnnotations;

namespace LokaleBookingRazor.Models
{
    public class Booking
    {
        [Key]
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
