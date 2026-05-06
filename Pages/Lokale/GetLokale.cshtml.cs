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

        public IActionResult OnGet()
        {
            if (LogInModel.LoggedInBruger == null)
                return RedirectToPage("/Login/LogIn");

            Lokaler = _lokaleService.GetLokaler();
            Bookings = _bookingService.GetBookings();
            Brugere = _brugerService.GetBrugere();
            return Page();
        }
    }
}
