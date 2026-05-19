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

        public Task<List<Lokale>> SearchLokaleByName(string input)
        {
            return _dbservice.SearchLokaleByName(input);
        }

        public Task<List<Lokale>> SortLokaleAscending()
        {
            return _dbservice.SortLokaleAscending();
        }

        public Task<List<Lokale>> SortLokaleDescending()
        {
            return _dbservice.SortLokaleDescending();
        }

        public Task<List<Lokale>> SortLokalerType(int id)
        {
            return _dbservice.SortLokalerType(id);
        }
    }
}
