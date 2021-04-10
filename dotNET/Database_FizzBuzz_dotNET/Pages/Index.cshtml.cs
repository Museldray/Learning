using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Database_FizzBuzz_dotNET.Models;

using Microsoft.AspNetCore.Http;

namespace Database_FizzBuzz_dotNET
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public FizzBuzz fizzbuzz { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                fizzbuzz.Result = fizzbuzz.CheckResult(fizzbuzz.Number);

                fizzbuzz.Date = DateTime.Now;
                HttpContext.Session.SetString("Wynik", JsonConvert.SerializeObject(fizzbuzz));

                return Page();
            }
        }
    }
}
