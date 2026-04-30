using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.MockData
{
    public class MockLokaler
    {
        private static List<Lokale> _lokaler = new List<Lokale>()
        {
            new Lokale { Navn = "Møde Rum", Beskrivelse = "Sejt rum", SmartBoard = true, Størrelse = 50, Type = 2, Booking = null },
            new Lokale { Navn = "Klasse Rum", Beskrivelse = "Sejt rum", SmartBoard = false, Størrelse = 50, Type = 1, Booking = null },
            new Lokale { Navn = "Auditorium", Beskrivelse = "Sejt rum", SmartBoard = true, Størrelse = 150, Type = 3, Booking = null },
        };

        public static List<Lokale> GetLokaler()
        {
            return _lokaler;
        }
    }
}
