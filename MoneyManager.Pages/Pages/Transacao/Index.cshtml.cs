using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoneyManager.Pages.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoneyManager.Pages.Pages.Transacao
{
    public class Index : PageModel
    {
        [BindProperty]
        public List<TransacaoModel> TransacaoList { get; set; } = new List<TransacaoModel>();

        public Index()
        {
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var httpClient = new HttpClient();
            var url = "http://webapi/api/Transacao";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                TransacaoList = JsonConvert.DeserializeObject<List<TransacaoModel>>(content);
            }
            else
            {
                
            }

            return Page();
        }
    }
}
