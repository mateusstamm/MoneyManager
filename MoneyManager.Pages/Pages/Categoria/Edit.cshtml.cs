using MoneyManager.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace MoneyManager.Pages.Pages.Categoria
{
    public class Edit : PageModel
    {   
        [BindProperty]
        public CategoriaModel CategoriaModel { get; set; } = new();
    
        public Edit(){
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var url = $"http://webapi/api/Categoria/{id}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var content = await response.Content.ReadAsStringAsync();
            CategoriaModel = JsonConvert.DeserializeObject<CategoriaModel>(content)!;

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int id){
            if(!ModelState.IsValid){
                return Page();
            }

            var httpClient = new HttpClient();
            var url = $"http://webapi/api/Categoria/{id}";
            var categoriaJson = Newtonsoft.Json.JsonConvert.SerializeObject(CategoriaModel);

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, url);
            requestMessage.Content = new StringContent(categoriaJson, Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(requestMessage);

            if(!response.IsSuccessStatusCode){
                return Page();
            }

            return RedirectToPage("/Categoria/Index");
        }
    }
}