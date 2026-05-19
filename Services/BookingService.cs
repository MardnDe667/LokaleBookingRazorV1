using LokaleBookingRazor.Models;
using LokaleBookingRazor.Pages.Login;

namespace LokaleBookingRazor.Services
{
    public class BookingService : IBookingService
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

        public Task<List<Booking>> SearchBookingByName(string input)
        {
            return _dbservice.SearchBookingByName(input);
        }

        public Task<List<Booking>> FilterByTime(DateTime? startTid, DateTime? slutTid)
        {
            return _dbservice.FilterByTime(startTid, slutTid);
        }

        public Task<List<Booking>> PersonalBookings(Bruger bruger)
        {
            return _dbservice.PersonalBookings(bruger);
        }

        public bool CanEditOrDelete(Booking booking)
        {
            if (LogInModel.LoggedInBruger == null)
                return false;

            var tidIndtilBooking = booking.StartTid - DateTime.Now;

            if (LogInModel.LoggedInBruger.Rolle == "Underviser" && tidIndtilBooking.TotalDays >= 3)
                return true;

            if (DateTime.Now > booking.StartTid)
                return false;

            return booking.BrugerId == LogInModel.LoggedInBruger.Id;
        }
    }
}