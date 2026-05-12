using LokaleBookingRazor.EFDbContext;
using LokaleBookingRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LokaleBookingRazor.Services
{
    public class DBBookingService
    {
        private readonly BookingDbContext _context;

        public DBBookingService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBooking(Booking booking)
        {
            using (var context = new BookingDbContext())
            {
                context.Bookings.Remove(booking);
                context.SaveChanges();
            }
        }

        public async Task SaveBookings(List<Booking> bookings)
        {
            _context.Bookings.AddRange(bookings);
            await _context.SaveChangesAsync();
        }
    }
}
