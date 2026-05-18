using LokaleBookingRazor.Models;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace LokaleBookingRazor.Pages.Login
{
    public class LogInModel : PageModel
    {
        private BrugerService _brugerService;

        public static Bruger LoggedInBruger { get; set; } = null;

        [BindProperty]
        public string Brugernavn { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }

        public LogInModel(BrugerService brugerService)
        {
            _brugerService = brugerService; 
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            List<Bruger> brugere = await _brugerService.GetBrugere();
            foreach (Bruger bruger in brugere)
            {

                if (Brugernavn == bruger.Brugernavn)
                {
                    var passwordHasher = new PasswordHasher<string>();

                    if (passwordHasher.VerifyHashedPassword(null, bruger.Password, Password) == PasswordVerificationResult.Success)
                    {

                        LoggedInBruger = bruger;

                        var claims = new List<Claim> { new Claim(ClaimTypes.Name, Brugernavn) };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Lokale/GetLokale");

                    }

                }
            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}
