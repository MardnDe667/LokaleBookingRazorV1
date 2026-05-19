using LokaleBookingRazor.Pages.Login;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LokaleBookingRazor.Pages.Booking
{
    public class DeleteBookingModel : PageModel
    {
        private BookingService _bookingService;

        public DeleteBookingModel(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty]
        public Models.Booking? Booking { get; set; }

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

        public async Task<IActionResult> OnPost()
        {
            await _bookingService.DeleteBooking(Booking);

            return RedirectToPage("/Lokale/GetLokale");
        }
    }   
}
