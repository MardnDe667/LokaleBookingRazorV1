using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.EFDbContext
{
    public class BookingDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookingDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Bruger> Brugere { get; set; }
        public DbSet<Lokale> Lokaler { get; set; }
    }
}