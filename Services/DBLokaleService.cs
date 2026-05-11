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

        public async Task SaveLokaler(List<Lokale> lokaler)
        {
            _context.Lokaler.AddRange(lokaler);
            await _context.SaveChangesAsync();
        }
    }
}