using LokaleBookingRazor.MockData;
using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.Services
{
    public class BrugerService
    {
        public List <Bruger> TestBrugere { get; set; }
        private DBBrugerService _dbservice { get; set; }
        private List<Bruger> _brugere;

        public Bruger LoggedInBruger { get; set; } // Den bruger som er logged ind..

        public BrugerService(DBBrugerService dbservice)
        {
            
            _dbservice = dbservice;
            TestBrugere = MockData.MockBrugere.GetBrugere();
            //_brugere = _dbservice.GetBrugere().Result;
        }
        public List<Bruger> GetBrugere()
        {
            return _brugere;
        }
    }
}
