using LokaleBookingRazor.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LokaleBookingRazor.Pages.Lokale
{
    public class GetLokaleModel : PageModel
    {
        private LokaleService _lokaleService;

        public GetLokaleModel(LokaleService lokaleService)
        {
            _lokaleService = lokaleService;
        }

        public List<Models.Lokale> Lokaler { get; set; } = new();

        public void OnGet()
        {
            Lokaler = _lokaleService.GetLokaler();
        }
    }
}
