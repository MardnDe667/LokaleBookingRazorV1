using LokaleBookingRazor.MockData;
using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.Services
{
    public class LokaleService
    {
        private DBLokaleService _dbservice { get; set; }

        public LokaleService(DBLokaleService dbservice)
        {
            _dbservice = dbservice;
        }

        public Task<List<Lokale>> GetLokaler()
        {
            return _dbservice.GetLokaler();
        }

        public Task<Lokale?> GetLokale(int id)
        {
            return _dbservice.GetLokale(id);
        }
    }
}
