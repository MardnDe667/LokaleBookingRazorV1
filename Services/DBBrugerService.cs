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

        public async Task SaveBrugere(List<Bruger> brugere)
        {
            _context.Brugere.AddRange(brugere);
            await _context.SaveChangesAsync();
        }
    }
}