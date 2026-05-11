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


        public void OnGet(int id)
        {
            // not done
        }
    }
}
