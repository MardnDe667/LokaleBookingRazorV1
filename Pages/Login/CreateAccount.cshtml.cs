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
    public class CreateAccountModel : PageModel
        {
            private IBrugerService _brugerService;


        [BindProperty]
        public Models.Bruger? Bruger { get; set; } // Den nye booking
        public string Message { get; set; }

            public CreateAccountModel(IBrugerService brugerService)
            {
                _brugerService = brugerService;
            }

            public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var brugere = await _brugerService.GetBrugereByName(Bruger.Brugernavn);

            if (brugere.Count > 1)
            {
                ModelState.AddModelError("", "Der findes allerede en bruger med dette navn.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Opret bruger 
            Bruger newBruger = new Bruger

            {
                Brugernavn = Bruger.Brugernavn,
                Rolle = Bruger.Rolle
            };

            var passwordHasher = new PasswordHasher<Bruger>();
            newBruger.Password = passwordHasher.HashPassword(newBruger, Bruger.Password);

            //gem i DB
            await _brugerService.AddBruger(newBruger);
            //opdater rolle, og opret i DB
            Message = "Din brugerprofil er nu oprettet!";
            return RedirectToPage("/Login/login");
        }
    }
}
