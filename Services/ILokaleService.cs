using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.Services
{
    public interface ILokaleService
    {
        Task<List<Lokale>> GetLokaler();
        Task<Lokale?> GetLokale(int id);
        Task<List<Lokale>> SearchLokaleByName(string input);
        Task<List<Lokale>> SortLokaleAscending();
        Task<List<Lokale>> SortLokaleDescending();
        Task<List<Lokale>> SortLokalerType(int id);
        Task<List<Lokale>> SortBygningTal(char? bygningTal);

    }
}
