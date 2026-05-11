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

        [Display(Name = "Booking Navn")]
        [Required(ErrorMessage = "Booking Navn skal tilføjes.")]
        [StringLength(100)]
        public string Navn { get; set; }

        [Display(Name = "Booking Beskrivelse")]
        [Required(ErrorMessage = "Booking Beskrivelse skal tilføjes.")]
        [StringLength(1000)]
        public string Beskrivelse { get; set; }

        [Display(Name = "Start Tid")]
        [Required(ErrorMessage = "Start tid skal tilføjes.")]
        public DateTime StartTid { get; set; }

        [Display(Name = "Slut Tid")]
        [Required(ErrorMessage = "Slut tid skal tilføjes.")]
        public DateTime SlutTid { get; set; }

        public int BrugerId { get; set; }
        public int LokaleId { get; set; }

        public Booking(int id, string navn, string beskrivelse, DateTime startTid, DateTime slutTid, int brugerId, int lokaleId)
        {
            Id = id;
            Navn = navn;
            Beskrivelse = beskrivelse;
            StartTid = startTid;
            SlutTid = slutTid;
            BrugerId = brugerId;
            LokaleId = lokaleId;
        }

        public Booking()
        {
            Id = 0;
            Navn = "";
            Beskrivelse = "";
            StartTid = DateTime.Now;
            SlutTid = DateTime.Now;
            BrugerId = 0;
            LokaleId = 0;
        }
    }
}