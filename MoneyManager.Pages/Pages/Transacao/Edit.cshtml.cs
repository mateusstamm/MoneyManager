using MoneyManager.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Pages.Pages.Transacao
{
    public class Edit : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty]
        public TransacaoModel TransacaoModel { get; set; }

        public List<SelectListItem> CategoriaList { get; set; }

        public Edit()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = $"http://webapi/api/Transacao/{id}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var content = await response.Content.ReadAsStringAsync();
            TransacaoModel = JsonConvert.DeserializeObject<TransacaoModel>(content);

            await LoadCategoriaList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                await LoadCategoriaList();
                return Page();
            }

            // Set the CategoriaID for the TransacaoModel
            TransacaoModel.CategoriaID = int.Parse(Request.Form["TransacaoModel.CategoriaID"]);

            var url = $"http://webapi/api/Transacao/{id}";
            var transacaoJson = JsonConvert.SerializeObject(TransacaoModel);

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, url);
            requestMessage.Content = new StringContent(transacaoJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                await LoadCategoriaList();
                return Page();
            }

            return RedirectToPage("/Transacao/Index");
        }

        private async Task LoadCategoriaList()
        {
            var url = "http://webapi/api/Categoria";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categorias = JsonConvert.DeserializeObject<List<CategoriaModel>>(content);

                CategoriaList = categorias.Select(c => new SelectListItem { Value = c.CategoriaID.ToString(), Text = c.Nome }).ToList();
            }
        }
    }
}
