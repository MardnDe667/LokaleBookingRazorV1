using LokaleBookingRazor.Models;
using LokaleBookingRazor.Pages.Login;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;


namespace LokaleBookingRazor.Pages.Booking
{
    public class GetBookingModel : PageModel
    {
        private BookingService _bookingService;
        private LokaleService _lokaleService;
        private BrugerService _brugerService;

        public GetBookingModel(LokaleService lokaleService, BookingService bookingService, BrugerService brugerService)
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
