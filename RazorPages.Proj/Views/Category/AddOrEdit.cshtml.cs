using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Proj.Models;

namespace RazorPages.Proj.Pages
{
    public class AddOrEditModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        public void OnGet(int id)
        {
            // Lógica para carregar os dados da categoria com o ID fornecido
            // e preencher a propriedade Category
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Lógica para adicionar ou editar a categoria no banco de dados

            return RedirectToPage("Index"); // Redirecionar para a página Index após adicionar/editar a categoria
        }
    }
}
