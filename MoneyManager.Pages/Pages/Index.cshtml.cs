using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Pages.Models;
using System.Text;
using System;
using Newtonsoft.Json;

namespace MoneyManager.Pages.Pages
{
    public class Index : PageModel
    {
        public Index(){
        }

        public async Task<IActionResult> OnGetAsync(){
            
            return Page();
        }
    }
}