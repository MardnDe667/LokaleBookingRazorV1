using LokaleBookingRazor.EFDbContext;
using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.Services
{
    public class DBLokaleService
    {
        private readonly BookingDbContext _context;

        public DBLokaleService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lokale>> GetLokaler()
        {
            return await _context.Lokaler.ToListAsync();
        }

        public async Task<Lokale?> GetLokale(int id)
        {
            return await _context.Lokaler.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task SaveLokaler(List<Lokale> lokaler)
        {
            await _context.Lokaler.AddRangeAsync(lokaler);
            await _context.SaveChangesAsync();
        }
    }
}
