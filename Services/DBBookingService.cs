using LokaleBookingRazor.EFDbContext;
using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.Services
{
    public class DBBookingService
    {
        public async Task<List<Booking>> GetBookings()
        {
            using (var context = new BookingDbContext())
            {
                return await context.Bookings.ToListAsync();
            }
        }

        public async Task AddBooking(Booking booking)
        {
            using (var context = new BookingDbContext())
            {
                context.Bookings.Add(booking);
                context.SaveChanges();
            }
        }

        public async Task SaveBookings(List<Booking> bookings)
        {
            using (var context = new BookingDbContext())
            {
                foreach (Booking booking in bookings)
                {
                    context.Bookings.Add(booking);
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    }
}
