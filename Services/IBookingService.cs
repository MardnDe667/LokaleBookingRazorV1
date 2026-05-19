using LokaleBookingRazor.Models;

namespace LokaleBookingRazor.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookings();
        Task<Booking?> GetBooking(int id);
        Task AddBooking(Booking booking);
        Task UpdateBooking(Booking booking);
        Task DeleteBooking(Booking booking);

        Task<List<Booking>> SearchBookingByName(string input);
        Task<List<Booking>> FilterByTime(DateTime? startTid, DateTime? slutTid);
        Task<List<Booking>> PersonalBookings(Bruger bruger);

        bool CanEditOrDelete(Booking booking);
    }
}
