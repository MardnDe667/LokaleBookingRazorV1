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

        [BindProperty]
        public DateTime StartTid { get; set; }
        [BindProperty]
        public DateTime SlutTid { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Lokaler = await _lokaleService.GetLokaler();
            Bookings = await _bookingService.GetBookings();
            Brugere = await _brugerService.GetBrugere();

            return Page();
        }

        public async Task<IActionResult> OnPostFilterTimeAsync()
        {
            Lokaler = await _lokaleService.GetLokaler();
            Brugere = await _brugerService.GetBrugere();

            Bookings = await _bookingService.FilterByTime(StartTid, SlutTid);
            return Page();
        }

        public bool CanEditOrDelete(Models.Booking booking)
        {
            return _bookingService.CanEditOrDelete(booking);
        }
    }
}
