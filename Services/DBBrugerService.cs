using LokaleBookingRazor.EFDbContext;
using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.Services
{
    public class DBBrugerService
    {
        public async Task<List<Bruger>> GetBrugere()
        {
            using (var context = new BookingDbContext())
            {
                return await context.Brugere.ToListAsync();
            }
        }

        public async Task SaveBrugere(List<Bruger> brugere)
        {
            using (var context = new BookingDbContext())
            {
                foreach (Bruger bruger in brugere)
                {
                    context.Brugere.Add(bruger);
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    }
}
