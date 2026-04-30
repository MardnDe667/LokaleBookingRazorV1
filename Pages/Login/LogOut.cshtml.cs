using LokaleBookingRazor.Models;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace LokaleBookingRazor.Pages.Login
{
    public class LogOutModel : PageModel
    {
        public Bruger User { get; set; }
        private BrugerService _brugerService;

        public LogOutModel(BrugerService brugerService)
        {
            _brugerService = brugerService;
        }

        public IActionResult OnGet()
        {
            if (_brugerService.LoggedInBruger == null)
                return RedirectToPage("/Error");

            User = _brugerService.LoggedInBruger;
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            await _brugerService.LogOut();
            return RedirectToPage("/Lokale/GetLokale");
        }
    }
}
