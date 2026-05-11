using LokaleBookingRazor.Models;
using LokaleBookingRazor.Pages.Login;

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

        public async Task DeleteBooking(Booking booking)
        {
            await _dbservice.DeleteBooking(booking);

            _bookings = _dbservice.GetBookings().Result;
        }

        public List<Booking> GetBookings()
        {
            return _bookings;
        }

        public Booking GetBooking(int id)
        {
            foreach (Booking booking in _bookings)
            {
                if (booking.Id == id)
                    return booking;
            }

            return null;
        }

        public bool CanDelete(Models.Booking booking)
        {
            if (LogInModel.LoggedInBruger == null)
                return false;

            var tidIndtilBooking = booking.StartTid - DateTime.Now;

            if (LogInModel.LoggedInBruger.Rolle == "Underviser" && tidIndtilBooking.TotalDays >= 3)
            {
                return true;
            }

            return booking.BrugerId == LogInModel.LoggedInBruger.Id;
        }
    }
}
