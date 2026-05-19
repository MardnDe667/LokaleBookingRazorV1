using LokaleBookingRazor.Models;
using LokaleBookingRazor.Pages.Login;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LokaleBookingRazor.Pages.Booking
{
    public class CreateBookingModel : PageModel
    {
        private LokaleService _lokaleService;
        private BookingService _bookingService;

        public CreateBookingModel(LokaleService lokaleService, BookingService bookingService)
        {
            _lokaleService = lokaleService;
            _bookingService = bookingService;
        }

        [BindProperty]
        public Models.Booking? Booking { get; set; } // Den nye booking

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var lokale = await _lokaleService.GetLokale(id);
            if (lokale == null)
                return RedirectToPage("/Error");

            Booking = new Models.Booking(); // Indsæt default values

            Booking.LokaleId = id; // Tilføj Lokale Id til ny Booking
            Booking.BrugerId = LogInModel.LoggedInBruger.Id; // Set Bruger Id til ny Booking

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

            var bookings = await _bookingService.GetBookings(); // henter bookings
            var overlap = bookings.Where(booking => booking.LokaleId == Booking.LokaleId && booking.StartTid < Booking.SlutTid && booking.SlutTid > Booking.StartTid).ToList(); // Liste over bookings der matcher det samme tidspunkt som binded.

            switch (lokale.Type) // Tjek Lokale type og find restrictions
            {
                case 1:
                    if (varighed.TotalHours > 6 || varighed.TotalHours < 0.5)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Maks 6 timer og mindst en halv time");
                    }

                    else if (overlap.Count > 1)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Dette lokale er allerede booket af 2 personer, på dette tidspunkt");
                    }
                    
                    break;

                case 2:
                    if (varighed.TotalHours > 3 || varighed.TotalHours < 0.5)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Maks 3 timer og mindst en halv time");
                    }

                    else if (overlap.Count > 0)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Dette lokale er allerede booket af en person, på dette tidspunkt");
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

                    else if (overlap.Count > 1)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Dette lokale er allerede booket af 2 personer, på dette tidspunkt");
                    }

                    break;

                case 4:
                    if (varighed.TotalHours > 6 || varighed.TotalHours < 0.5)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Maks 1 time og mindst en halv time");
                    }

                    else if (overlap.Count > 1)
                    {
                        ModelState.AddModelError("Booking.SlutTid", "Dette lokale er allerede booket af 2 personer, på dette tidspunkt");
                    }

                    break;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _bookingService.AddBooking(Booking);
            return RedirectToPage("/Lokale/GetLokale");
        }
    }
}
