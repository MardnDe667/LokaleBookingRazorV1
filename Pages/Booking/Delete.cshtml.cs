using LokaleBookingRazor.Pages.Login;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LokaleBookingRazor.Pages.Booking
{
    public class DeleteModel : PageModel
    {
        private BookingService _bookingService;

        public DeleteModel(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty]
        public Models.Booking Booking { get; set; }


        public IActionResult OnGet(int id)
        {
            Booking = _bookingService.GetBooking(id);
            if (Booking == null)
                return RedirectToPage("/Error"); //NotFound er ikke defineret endnu

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _bookingService.DeleteBooking(Booking);

            return RedirectToPage("/Lokale/GetLokale");
        }
    }   
}
