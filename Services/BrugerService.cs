using LokaleBookingRazor.MockData;
using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.Services
{
    public class BrugerService
    {
        private DBBrugerService _dbservice { get; set; }
        private List<Bruger> _brugere;

        public BrugerService(DBBrugerService dbservice)
        {
            
            _dbservice = dbservice;

            _brugere = _dbservice.GetBrugere().Result;
        }
        public List<Bruger> GetBrugere()
        {
            return _brugere;
        }
    }
}
