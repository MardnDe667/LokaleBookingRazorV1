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
        private IBookingService _bookingService;
        private ILokaleService _lokaleService;
        private IBrugerService _brugerService;

        public GetLokaleModel(ILokaleService lokaleService, IBookingService bookingService, IBrugerService brugerService)
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
        [BindProperty]
        public char BygningInput { get; set; }

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

        public async Task<IActionResult> OnPostSortAscendingAsync()
        {
            Bookings = await _bookingService.GetBookings();
            Brugere = await _brugerService.GetBrugere();

            Lokaler = await _lokaleService.SortLokaleAscending();
            return Page();
        }

        public async Task<IActionResult> OnPostSortDescendingAsync()
        {
            Bookings = await _bookingService.GetBookings();
            Brugere = await _brugerService.GetBrugere();

            Lokaler = await _lokaleService.SortLokaleDescending();
            return Page();
        }

        public async Task<IActionResult> OnPostSortKlasseLokalerAsync()
        {
            Bookings = await _bookingService.GetBookings();
            Brugere = await _brugerService.GetBrugere();

            Lokaler = await _lokaleService.SortLokalerType(1);
            return Page();
        }

        public async Task<IActionResult> OnPostSortMødeLokalerAsync()
        {
            Bookings = await _bookingService.GetBookings();
            Brugere = await _brugerService.GetBrugere();

            Lokaler = await _lokaleService.SortLokalerType(2);
            return Page();
        }

        public async Task<IActionResult> OnPostSortAuditoriumAsync()
        {
            Bookings = await _bookingService.GetBookings();
            Brugere = await _brugerService.GetBrugere();

            Lokaler = await _lokaleService.SortLokalerType(3);
            return Page();
        }

        public async Task<IActionResult> OnPostSortGruppeLokalerAsync()
        {
            Bookings = await _bookingService.GetBookings();
            Brugere = await _brugerService.GetBrugere();

            Lokaler = await _lokaleService.SortLokalerType(4);
            return Page();
        }

        public async Task<IActionResult> OnPostSortBygningTalAsync()
        {
            Bookings = await _bookingService.GetBookings();
            Brugere = await _brugerService.GetBrugere();

            Lokaler = await _lokaleService.SortBygningTal(BygningInput);
            return Page();
        }

        public bool CanEditOrDelete(Models.Booking booking)
        {
            return _bookingService.CanEditOrDelete(booking);
        }
    }
}
