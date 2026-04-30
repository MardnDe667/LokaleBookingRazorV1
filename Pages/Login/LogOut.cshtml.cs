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
        private BrugerService _brugerService;

        public LogOutModel(BrugerService brugerService)
        {
            _brugerService = brugerService;
        }

        public IActionResult OnGet()
        {
            if (LogInModel.LoggedInBruger == null)
                return RedirectToPage("/Error");

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            LogInModel.LoggedInBruger = null;

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/index");
        }
    }
}
