using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.EFDbContext
{
    public class BookingDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString =
                Environment.GetEnvironmentVariable(
                    "ConnectionStrings__DefaultConnection");

            options.UseSqlServer(connectionString);
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Bruger> Brugere { get; set; }
        public DbSet<Lokale> Lokaler { get; set; }
    }
}