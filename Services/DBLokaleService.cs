using LokaleBookingRazor.EFDbContext;
using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.Services
{
    public class DBLokaleService
    {
        public async Task<List<Lokale>> GetLokaler()
        {
            using (var context = new BookingDbContext())
            {
                return await context.Lokaler.ToListAsync();
            }
        }

        public async Task SaveLokaler(List<Lokale> lokaler)
        {
            using (var context = new BookingDbContext())
            {
                foreach (Lokale lokale in lokaler)
                {
                    context.Lokaler.Add(lokale);
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    }
}
