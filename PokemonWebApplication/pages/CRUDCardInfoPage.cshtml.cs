using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PokemonWebApplication.pages
{
    public class CRUDCardInfoPageModel : PageModel
    {
        public string CardId { get; private set; } = "pages in pokemon card";

        public void OnGet()
        {
            CardId += $"11111";
        }
    }
}
