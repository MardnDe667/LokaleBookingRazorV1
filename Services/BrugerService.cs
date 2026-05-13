using LokaleBookingRazor.MockData;
using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.Services
{
    public class BrugerService
    {
        private DBBrugerService _dbservice { get; set; }

        public BrugerService(DBBrugerService dbservice)
        {
            _dbservice = dbservice;
        }

        public Task<List<Bruger>> GetBrugere()
        {
            return _dbservice.GetBrugere();
        }

        public Task<Bruger?> GetBruger(int id)
        {
            return _dbservice.GetBruger(id);
        }
    }
}
