using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS3_dotNET.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace PS3_dotNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public Address Address { get; set; }

        [BindProperty]
        public int Liczba { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public void OnGet()
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(Address));
            HttpContext.Session.SetInt32("Liczba", Liczba);
            return RedirectToPage("./Address");
        }
    }
}
