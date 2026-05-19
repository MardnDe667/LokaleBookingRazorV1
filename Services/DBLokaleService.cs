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

        public async Task<List<Lokale>> SearchLokaleByName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return await _context.Lokaler.ToListAsync();

            return await _context.Lokaler.Where(l => l.Navn.Contains(input)).ToListAsync();
        }

        public async Task<List<Lokale>> SortLokaleAscending()
        {
            return await _context.Lokaler.OrderBy(l => l.Navn).ToListAsync();
        }

        public async Task<List<Lokale>> SortLokaleDescending()
        {
            return await _context.Lokaler.OrderByDescending(l => l.Navn).ToListAsync();
        }

        public async Task<List<Lokale>> SortLokalerType(int id)
        {
            return await _context.Lokaler.Where(l => l.Type == id).ToListAsync();
        }

        public async Task<List<Lokale>> SortBygningTal(char? bygningTal)
        {
            if (bygningTal == '\0')
                return await _context.Lokaler.ToListAsync();

            return await _context.Lokaler.Where(l => l.BygningTal == bygningTal).ToListAsync();
        }
    }
}
