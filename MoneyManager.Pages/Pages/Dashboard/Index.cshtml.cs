using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoneyManager.Pages.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoneyManager.Pages.Pages.Dashboard
{
    public class Index : PageModel
    {
        private readonly HttpClient _httpClient;

        public decimal GastoTotal { get; set; }
        public decimal ReceitaTotal { get; set; }
        public decimal SaldoTotal { get; set; }

        public List<CategoriaModel> CategoriaList { get; set; }
        public List<TransacaoModel> TransacaoList { get; set; }

        public DashboardModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadCategoriasAsync();
            await LoadTransacoesAsync();

            GastoTotal = TransacaoList
                .Where(t => CategoriaList.Any(c => c.CategoriaID == t.CategoriaID && c.Tipo == TipoCategoria.Gasto))
                .Sum(t => t.Valor);

            ReceitaTotal = TransacaoList
                .Where(t => CategoriaList.Any(c => c.CategoriaID == t.CategoriaID && c.Tipo == TipoCategoria.Receita))
                .Sum(t => t.Valor);

            SaldoTotal = ReceitaTotal - GastoTotal;

            return Page();
        }

        private async Task LoadCategoriasAsync()
        {
            var response = await _httpClient.GetAsync("http://webapi/api/Categoria");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                CategoriaList = JsonConvert.DeserializeObject<List<CategoriaModel>>(content);
            }
            else
            {
                // Lidar com o erro de requisição
            }
        }

        private async Task LoadTransacoesAsync()
        {
            var response = await _httpClient.GetAsync("http://webapi/api/Transacao");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                TransacaoList = JsonConvert.DeserializeObject<List<TransacaoModel>>(content);
            }
            else
            {
                // Lidar com o erro de requisição
            }
        }
    }
}
