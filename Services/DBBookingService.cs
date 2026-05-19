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

        public async Task<Booking?> GetBooking(int id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Booking>> SearchBookingByName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return await _context.Bookings.ToListAsync();

            return await _context.Bookings.Where(b => b.Navn.Contains(input)).ToListAsync();
        }

        public async Task AddBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Booking>> FilterByTime(DateTime? startTid, DateTime? slutTid)
        {
            if (startTid == DateTime.MinValue || slutTid == DateTime.MinValue)
                return await _context.Bookings.ToListAsync();

            return await _context.Bookings.Where(b => b.StartTid < slutTid && b.SlutTid > startTid).ToListAsync();
        }

        public async Task<List<Booking>> PersonalBookings(Bruger bruger)
        {
            return await _context.Bookings.Where(b => b.BrugerId == bruger.Id).ToListAsync();
        }

        public async Task SaveBookings(List<Booking> bookings)
        {
            await _context.Bookings.AddRangeAsync(bookings);
            await _context.SaveChangesAsync();
        }
    }
}