using MoneyManager.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoneyManager.Pages.Pages.Categoria
{
    public class Create : PageModel
    {
        [BindProperty]
        public CategoriaModel CategoriaModel { get; set; } = new CategoriaModel();

        public Create()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var httpClient = new HttpClient();
            var url = "http://webapi/api/Categoria";
            var response = await httpClient.PostAsJsonAsync(url, CategoriaModel);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Categoria/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
