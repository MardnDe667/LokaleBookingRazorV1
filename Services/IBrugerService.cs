using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.Services
{
    public interface IBrugerService
    {
        Task<List<Bruger>> GetBrugere();
        Task<Bruger?> GetBruger(int id);
        Task AddBruger(Bruger bruger);
        Task<List<Bruger>> GetBrugereByName(string brugernavn);
    }
}
