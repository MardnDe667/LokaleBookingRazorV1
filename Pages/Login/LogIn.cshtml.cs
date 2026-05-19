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
        private readonly BrugerService _brugerService;

        public static Bruger LoggedInBruger { get; set; } = null;

        [BindProperty]
        [Required]
        public string Brugernavn { get; set; } = string.Empty;

        [BindProperty, DataType(DataType.Password)]
        [Required]
        public string Password { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty; 

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
