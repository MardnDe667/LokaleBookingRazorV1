using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.Services
{
    public class BookingService
    {
        private DBBookingService _dbservice { get; set; }
        private List<Booking> _bookings;

        public BookingService(DBBookingService dbservice)
        {
            _dbservice = dbservice;

            _bookings = _dbservice.GetBookings().Result;
        }


        public async Task AddBooking(Booking booking)
        {
            await _dbservice.AddBooking(booking);

            _bookings = _dbservice.GetBookings().Result;
        }

        public List<Booking> GetBookings()
        {
            return _bookings;
        }
    }
}
