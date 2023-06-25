using MoneyManager.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MoneyManager.Pages.Pages.Transacao
{
    public class Edit : PageModel
    {
        [BindProperty]
        public TransacaoModel TransacaoModel { get; set; } = new TransacaoModel();

        public List<SelectListItem> CategoriaList { get; set; } = new List<SelectListItem>();

        public Edit()
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpClient = new HttpClient();
            var url = $"http://webapi/api/Transacao/{id}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);

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

            var httpClient = new HttpClient();
            var url = $"http://webapi/api/Transacao/{id}";
            var transacaoJson = JsonConvert.SerializeObject(TransacaoModel);

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, url);
            requestMessage.Content = new StringContent(transacaoJson, Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                await LoadCategoriaList();
                return Page();
            }

            return RedirectToPage("/Transacao/Index");
        }

        private async Task LoadCategoriaList()
        {
            var httpClient = new HttpClient();
            var url = "http://webapi/api/Categoria";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categorias = JsonConvert.DeserializeObject<List<CategoriaModel>>(content);

                CategoriaList = categorias.Select(c => new SelectListItem { Value = c.CategoriaID.ToString(), Text = c.Nome }).ToList();
            }
        }
    }
}
