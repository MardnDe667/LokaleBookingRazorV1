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

            _lokaler = _dbservice.GetLokaler().Result;
        }

        public List<Lokale> GetLokaler()
        {
            return _lokaler;
        }

        public Lokale GetLokale(int id)
        {
            foreach (Lokale lokale in _lokaler)
            {
                if (lokale.Id == id)
                    return lokale;
            }

            return null;
        }
    }
}
