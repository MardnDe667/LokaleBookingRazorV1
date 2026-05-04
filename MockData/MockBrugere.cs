using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.MockData
{
    public class MockBrugere
    {
        private static List<Bruger> _brugere = new List<Bruger>()
        {
            new Bruger { Brugernavn = "JustHerring", Password = "NotAFish123", Rolle = "Elev" },
            new Bruger { Brugernavn = "1", Password = "123", Rolle = "Elev" },
            new Bruger { Brugernavn = "Henrik", Password = "Programmer123", Rolle = "Underviser" },
        };

        public static List<Bruger> GetBrugere()
        {
            return _brugere;
        }
    }
}
