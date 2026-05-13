using LokaleBookingRazor.Models;
using LokaleBookingRazor.Pages.Login;

namespace LokaleBookingRazor.Services
{
    public class BookingService
    {
        private DBBookingService _dbservice { get; set; }

        public BookingService(DBBookingService dbservice)
        {
            _dbservice = dbservice;
        }

        public Task<List<Booking>> GetBookings()
        {
            return _dbservice.GetBookings();
        }

        public Task<Booking?> GetBooking(int id)
        {
            return _dbservice.GetBooking(id);
        }

        public Task AddBooking(Booking booking)
        {
            return _dbservice.AddBooking(booking);
        }

        public Task UpdateBooking(Booking booking)
        {
            return _dbservice.UpdateBooking(booking);
        }

        public Task DeleteBooking(Booking booking)
        {
            return _dbservice.DeleteBooking(booking);
        }

        public bool CanEditOrDelete(Booking booking)
        {
            if (LogInModel.LoggedInBruger == null)
                return false;

            var tidIndtilBooking = booking.StartTid - DateTime.Now;

            if (LogInModel.LoggedInBruger.Rolle == "Underviser" && tidIndtilBooking.TotalDays >= 3)
                return true;

            if (tidIndtilBooking.TotalHours < 1)
                return false;

            return booking.BrugerId == LogInModel.LoggedInBruger.Id;
        }
    }
}