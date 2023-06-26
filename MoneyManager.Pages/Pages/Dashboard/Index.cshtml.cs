using Microsoft.AspNetCore.Mvc.RazorPages;
using MoneyManager.Pages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoneyManager.Pages.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public decimal GastoTotal { get; set; }
        public decimal ReceitaTotal { get; set; }
        public decimal SaldoTotal { get; set; }
        public List<TransacaoModel> Transacoes { get; set; }

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task OnGetAsync()
        {
            await LoadGastoTotalAsync();
            await LoadTransacoesAsync();
        }

        private async Task LoadGastoTotalAsync()
        {
            // Obter a lista de transações
            var transacoesResponse = await _httpClient.GetAsync("http://webapi/api/Transacao");
            if (transacoesResponse.IsSuccessStatusCode)
            {
                var transacoesContent = await transacoesResponse.Content.ReadAsStringAsync();
                var transacoes = JsonConvert.DeserializeObject<List<TransacaoModel>>(transacoesContent);

                // Obter a lista de categorias
                var categoriasResponse = await _httpClient.GetAsync("http://webapi/api/Categoria");
                if (categoriasResponse.IsSuccessStatusCode)
                {
                    var categoriasContent = await categoriasResponse.Content.ReadAsStringAsync();
                    var categorias = JsonConvert.DeserializeObject<List<CategoriaModel>>(categoriasContent);

                    // Calcular o Gasto Total
                    GastoTotal = transacoes
                        .Where(t => categorias.Any(c => c.CategoriaID == t.CategoriaID && c.Tipo == "Despesa"))
                        .Sum(t => (decimal)t.Valor);

                    ReceitaTotal = transacoes
                        .Where(t => categorias.Any(c => c.CategoriaID == t.CategoriaID && c.Tipo == "Receita"))
                        .Sum(t => (decimal)t.Valor);

                    SaldoTotal = ReceitaTotal - GastoTotal;
                }
                else
                {
                    // Lidar com o erro de requisição das categorias
                }
            }
            else
            {
                // Lidar com o erro de requisição das transações
            }
        }

        private async Task LoadTransacoesAsync()
        {
            var transacoesResponse = await _httpClient.GetAsync("http://webapi/api/Transacao");
            if (transacoesResponse.IsSuccessStatusCode)
            {
                var transacoesContent = await transacoesResponse.Content.ReadAsStringAsync();
                Transacoes = JsonConvert.DeserializeObject<List<TransacaoModel>>(transacoesContent);
            }
            else
            {
                // Lidar com o erro de requisição das transações
            }
        }

        public string FormatDate(DateTime? date)
        {
            return date?.ToString("yyyy-MM-dd");
        }
    }
}
