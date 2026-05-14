using LokaleBookingRazor.MockData;
using LokaleBookingRazor.Pages.Login;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LokaleBookingRazor.Pages.Lokale
{
    public class GetLokaleModel : PageModel
    {
        private BookingService _bookingService;
        private LokaleService _lokaleService;
        private BrugerService _brugerService;

        public GetLokaleModel(LokaleService lokaleService, BookingService bookingService, BrugerService brugerService)
        {
            _lokaleService = lokaleService;
            _bookingService = bookingService;
            _brugerService = brugerService;
        }

        public List<Models.Lokale> Lokaler { get; set; } = new();
        public List<Models.Booking> Bookings { get; set; } = new();
        public List<Models.Bruger> Brugere { get; set; } = new();

        [BindProperty]
        public string SearchString { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Lokaler = await _lokaleService.GetLokaler();
            Bookings = await _bookingService.GetBookings();
            Brugere = await _brugerService.GetBrugere();

            foreach (Models.Booking booking in Bookings)
            {
                if (booking.StartTid < DateTime.Now)
                {
                    await _bookingService.DeleteBooking(booking);
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSearchAsync()
        {
            Bookings = await _bookingService.GetBookings();
            Brugere = await _brugerService.GetBrugere();

            Lokaler = await _lokaleService.SearchLokaleByName(SearchString);
            return Page();
        }

        public bool CanEditOrDelete(Models.Booking booking)
        {
            return _bookingService.CanEditOrDelete(booking);
        }
    }
}
