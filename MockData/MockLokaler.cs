using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.MockData
{
    public class MockLokaler
    {
        private static List<Lokale> _lokaler = new List<Lokale>()
        {
            new Lokale { Navn = "Tokyo", Beskrivelse = "Moderne mødelokale med SmartBoard og plads til workshops.", SmartBoard = true, Størrelse = 40, Type = 2, BygningTal = 'A', SalNr = 2, LokaleNr = 01},

            new Lokale { Navn = "Paris", Beskrivelse = "Hyggeligt klasselokale velegnet til gruppearbejde.", SmartBoard = false, Størrelse = 30, Type = 1, BygningTal = 'B', SalNr = 3, LokaleNr = 01},

            new Lokale { Navn = "New York", Beskrivelse = "Stort møderum med moderne faciliteter og hurtigt netværk.", SmartBoard = true, Størrelse = 60, Type = 2, BygningTal = 'A', SalNr = 2, LokaleNr = 02},

            new Lokale { Navn = "Berlin", Beskrivelse = "Funktionelt undervisningslokale med fleksibel bordopstilling.", SmartBoard = false, Størrelse = 35, Type = 1, BygningTal = 'A', SalNr = 2, LokaleNr = 03},

            new Lokale { Navn = "Sydney", Beskrivelse = "Lyst lokale med SmartBoard og videokonferenceudstyr.", SmartBoard = true, Størrelse = 45, Type = 2, BygningTal = 'C', SalNr = 3, LokaleNr = 01},

            new Lokale { Navn = "Rio", Beskrivelse = "Kreativt rum til workshops og mindre præsentationer.", SmartBoard = true, Størrelse = 25, Type = 2, BygningTal = 'C', SalNr = 2, LokaleNr = 01},

            new Lokale { Navn = "Cairo", Beskrivelse = "Roligt undervisningslokale med plads til koncentreret arbejde.", SmartBoard = false, Størrelse = 28, Type = 1, BygningTal = 'C', SalNr = 2, LokaleNr = 02},

            new Lokale { Navn = "Toronto", Beskrivelse = "Mødelokale med god akustik og moderne teknologi.", SmartBoard = true, Størrelse = 55, Type = 2, BygningTal = 'A', SalNr = 3, LokaleNr = 01},

            new Lokale { Navn = "Barcelona", Beskrivelse = "Inspirerende lokale til kreative projekter og teamwork.", SmartBoard = true, Størrelse = 38, Type = 2, BygningTal = 'A', SalNr = 3, LokaleNr = 02},

            new Lokale { Navn = "Auditorium", Beskrivelse = "Stort auditorium til foredrag og præsentationer.", SmartBoard = true, Størrelse = 150, Type = 3 , BygningTal = 'B', SalNr = 3, LokaleNr = 02},
        };

        public static List<Lokale> GetLokaler()
        {
            return _lokaler;
        }
    }
}
