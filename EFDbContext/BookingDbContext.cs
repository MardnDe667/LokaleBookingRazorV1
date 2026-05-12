using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.EFDbContext
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options)
        {
            options.UseSqlServer(@"Data Source=mssql5.unoeuro.com;Initial Catalog=datacatalyst_dk_db_BookingDB;User ID=datacatalyst_dk;Password=np6radeAGb9BR5F3Hfcx;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Bruger> Brugere { get; set; }
        public DbSet<Lokale> Lokaler { get; set; }
    }
}