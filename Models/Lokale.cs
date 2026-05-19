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

        public char BygningTal { get; set; }

        public int SalNr { get; set; }

        public int LokaleNr { get; set; }


        public Lokale (int id, string navn, string beskrivelse, bool smartBoard, float størrelse, int type, char bygningTal, int salNr, int lokaleNr)
        {
            Id = id;
            Navn = navn;
            Beskrivelse = beskrivelse;
            SmartBoard = smartBoard;
            Størrelse = størrelse;
            Type = type;
            BygningTal = bygningTal;
            SalNr = salNr;
            LokaleNr = lokaleNr;
        }
        public Lokale()
        {
            Id = 0;
            Navn = "";
            Beskrivelse = "";
            SmartBoard = false;
            Størrelse = 0;
            Type = 0;
            BygningTal = '\0';
            SalNr = 0;
            LokaleNr = 0;
        }
    }

}
