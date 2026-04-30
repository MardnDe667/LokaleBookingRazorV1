using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.Services
{
    public class LokaleService
    {
        private DBLokaleService _dbservice { get; set; }
        private List<Lokale> _lokaler;

        public LokaleService(DBLokaleService dbservice)
        {
            _dbservice = dbservice;

            _lokaler = MockData.MockLokaler.GetLokaler();
        }

        public List<Lokale> GetLokaler()
        {
            return _lokaler;
        }
    }
}
