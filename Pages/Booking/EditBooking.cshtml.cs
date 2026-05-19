using LokaleBookingRazor.Models;
using LokaleBookingRazor.Pages.Login;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LokaleBookingRazor.Pages.Booking
{
    public class EditBookingModel : PageModel
    {

        private LokaleService _lokaleService;
        private BookingService _bookingService;

        public EditBookingModel(LokaleService lokaleService, BookingService bookingService)
        {
            _lokaleService = lokaleService;
            _bookingService = bookingService;
        }

        [BindProperty]
        public Models.Booking? Booking { get; set; } // Den nye booking

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Booking = await _bookingService.GetBooking(id);

            if (Booking == null)
                return RedirectToPage("/Error");

            if (!_bookingService.CanEditOrDelete(Booking))
            {
                return RedirectToPage("/Lokale/GetLokale");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (LogInModel.LoggedInBruger == null)
            {
                return RedirectToPage("/Login/LogIn");
            }

            var lokale = await _lokaleService.GetLokale(Booking.LokaleId);

            if (lokale == null)
            {
                ModelState.AddModelError("Booking.LokaleId", "Lokale findes ikke");
                return Page();
            }

            var varighed = Booking.SlutTid - Booking.StartTid; // Varighed af tid i timer binded i alt
            var tidIndtilBooking = Booking.StartTid - DateTime.Now; // Varighed af tid i dage binded før i dag

            switch (lokale.Type) // Tjek Lokale type og find restrictions
            {
                case 1:
                    if (varighed.TotalHours > 6 || varighed.TotalHours < 0.5)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Maks 6 timer og mindst en halv time");
                    }

                    break;

                case 2:
                    if (varighed.TotalHours > 3 || varighed.TotalHours < 0.5)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Maks 3 timer og mindst en halv time");
                    }

                    break;

                case 3:
                    if (varighed.TotalHours > 1 || varighed.TotalHours < 0.5)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Maks 1 time og mindst en halv time");
                    }

                    else if (tidIndtilBooking.TotalDays < 2)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Skal bookes mindst 2 dage i forvejen");
                    }

                    break;

                case 4:
                    if (varighed.TotalHours > 6 || varighed.TotalHours < 0.5)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Maks 1 time og mindst en halv time");
                    }

                    break;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _bookingService.UpdateBooking(Booking);
            return RedirectToPage("/Lokale/GetLokale");
        }
    }
}
