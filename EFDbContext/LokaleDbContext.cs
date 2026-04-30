using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.EFDbContext
{
    public class LokaleDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LokaleDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        }

        public DbSet<Lokale> Lokaler { get; set; }
    }
}