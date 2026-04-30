using LokaleBookingRazor.Pages.Login;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LokaleBookingRazor.Pages.Lokale
{
    public class GetLokaleModel : PageModel
    {
        private BrugerService _brugerService;
        private LokaleService _lokaleService;

        public GetLokaleModel(LokaleService lokaleService, BrugerService brugerService)
        {
            _lokaleService = lokaleService;
            _brugerService = brugerService;
        }

        public List<Models.Lokale> Lokaler { get; set; } = new();

        public IActionResult OnGet()
        {
            if (LogInModel.LoggedInBruger == null)
                return RedirectToPage("/Login/LogIn");

            Lokaler = _lokaleService.GetLokaler();
            return Page();
        }
    }
}
