using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoneyManager.Pages.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoneyManager.Pages.Pages.Categoria
{
    public class Index : PageModel
    {
        [BindProperty]
        public List<CategoriaModel> CategoriaList { get; set; } = new List<CategoriaModel>();

        public Index()
        {
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var httpClient = new HttpClient();
            var url = "http://webapi/api/Categoria";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                CategoriaList = JsonConvert.DeserializeObject<List<CategoriaModel>>(content);
            }
            else
            {
                
            }

            return Page();
        }
    }
}
