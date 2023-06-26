using MoneyManager.Pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoneyManager.Pages.Pages.Transacao
{
    public class Details : PageModel
    {
        [BindProperty]
        public TransacaoModel TransacaoModel { get; set; } = new TransacaoModel();

        public Details()
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

            return Page();
        }
    }
}
