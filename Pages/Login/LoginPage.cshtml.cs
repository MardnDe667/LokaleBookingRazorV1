using LokaleBookingRazor.Models;
using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace LokaleBookingRazor.Pages.Login
{
    public class LoginPageModel : PageModel
    {

       // public static Bruger LoggedInBruger { get; set; } = null;
        private BrugerService _brugerService;

        [BindProperty]
        public string Brugernavn { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }

        public LoginPageModel (BrugerService brugerService)
        {
            _brugerService = brugerService; 
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {

            List<Bruger> brugere = _brugerService.TestBrugere;
            foreach (Bruger bruger in brugere)
            {
                if (Brugernavn == bruger.Brugernavn && Password == bruger.Password)
                {
                    _brugerService.LoggedInBruger = bruger;

                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, Brugernavn) };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("/Lokale/GetLokale");
                }
            }
            Message = "Invalid attempt";
            return Page();

        }
    }
}
