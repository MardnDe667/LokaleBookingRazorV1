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
            private BrugerService _brugerService;

           
            [BindProperty]
            [Required]
            public string Brugernavn { get; set; }

            [BindProperty, DataType(DataType.Password)]
            [Required]
            public string Password { get; set; }
            public string Message { get; set; }

            [BindProperty]
            [Required]
            public string Rolle { get; set; }


        //Sikrer at password er korrekt indtastet af brugeren 
        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match! ")]
        public string ConfirmPassword { get; set; }

            public CreateAccountModel(BrugerService brugerService)
            {
                _brugerService = brugerService;
            }

            public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)

            {
                return Page();
            }

            // checker om brugeren allerede findes i DB
            //Bruger existingBruger = await _brugerService.GetBrugere(Brugernavn);

            //if (existingBruger != null)

            //{

            //    Message = "Brugernavnet er allerede optaget. Indtast et nyt brugernavn.";
            //    return Page();
            //}

            //Opret bruger 
            Bruger newBruger = new Bruger

            {
                Brugernavn = Brugernavn
            };

            var passwordHasher = new PasswordHasher<Bruger>();
            newBruger.Password = passwordHasher.HashPassword(newBruger, Password);

            //gem i DB
            await _brugerService.AddBruger(newBruger);

            Message = "Din brugerprofil er nu oprettet!";

            return RedirectToPage("/Login/login");
        }
    }
}
