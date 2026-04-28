using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LokaleBookingRazor.Pages.Lokale
{
    public class GetLokaleModel : PageModel
    {
        public List<Models.Lokale> Lokaler { get; private set; } = new List<Models.Lokale>
        {
            new Models.Lokale(1, "Møde Rum"),
            new Models.Lokale(2, "Klasse lokale"),
            new Models.Lokale(3, "Auditorium")
        };

        public void OnGet()
        {
        }
    }
}
