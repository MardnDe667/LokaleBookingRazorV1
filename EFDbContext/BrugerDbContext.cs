using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.EFDbContext
{
    public class BrugerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BrugerDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        }

        public DbSet<Bruger> Brugere { get; set; }
    }
}