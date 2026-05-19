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
        private IBrugerService _brugerService;

        public static Bruger? LoggedInBruger { get; set; } = null;


        [BindProperty]
        public Models.Bruger? Bruger { get; set; }
        public string Message { get; set; }

        public LogInModel(IBrugerService brugerService)
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

                if (Bruger.Brugernavn == bruger.Brugernavn)
                {
                    var passwordHasher = new PasswordHasher<string>();

                    if (passwordHasher.VerifyHashedPassword(null, bruger.Password, Bruger.Password) == PasswordVerificationResult.Success)
                    {

                        LoggedInBruger = bruger;

                        var claims = new List<Claim> { new Claim(ClaimTypes.Name, Bruger.Brugernavn) };

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
