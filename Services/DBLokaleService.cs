using LokaleBookingRazor.EFDbContext;
using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.Services
{
    public class DBLokaleService
    {
        public async Task<List<Lokale>> GetLokaler()
        {
            using (var context = new LokaleDbContext())
            {
                return await context.Lokaler.ToListAsync();
            }
        }

        public async Task SaveLokaler(List<Lokale> cards)
        {
            using (var context = new LokaleDbContext())
            {
                foreach (Lokale card in cards)
                {
                    context.Lokaler.Add(card);
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    }
}
