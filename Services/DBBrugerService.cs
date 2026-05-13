using LokaleBookingRazor.EFDbContext;
using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.Services
{
    public class DBBrugerService
    {
        private readonly BookingDbContext _context;

        public DBBrugerService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bruger>> GetBrugere()
        {
            return await _context.Brugere.ToListAsync();
        }

        public async Task<Bruger?> GetBruger(int id)
        {
            return await _context.Brugere.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task SaveBrugere(List<Bruger> brugere)
        {
            await _context.Brugere.AddRangeAsync(brugere);
            await _context.SaveChangesAsync();
        }
    }
}
