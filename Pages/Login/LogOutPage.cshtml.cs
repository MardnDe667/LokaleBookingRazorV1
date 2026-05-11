using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LokaleBookingRazor.Pages.Login
{
    public class LogOutPageModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            // = null;

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/index");
        }
    }
}
