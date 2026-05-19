using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Xml.Linq;

namespace LokaleBookingRazor.Models
{
    public class Lokale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Lokale ID")]
        public int Id { get; set; }

        public string Navn { get; set; }

        public string Beskrivelse { get; set; }

        public bool SmartBoard { get; set; }

        public float Størrelse { get; set; }

        public int Type { get; set; }


        public Lokale (int id, string navn, string beskrivelse, bool smartBoard, float størrelse, int type)
        {
            Id = id;
            Navn = navn;
            Beskrivelse = beskrivelse;
            SmartBoard = smartBoard;
            Størrelse = størrelse;
            Type = type;
        }
        public Lokale()
        {
            Id = 0;
            Navn = "";
            Beskrivelse = "";
            SmartBoard = false;
            Størrelse = 0;
            Type = 0;
        }
    }

}
