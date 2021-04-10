using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Database_FizzBuzz_dotNET.Models;
using Database_FizzBuzz_dotNET.Data;

using Microsoft.AspNetCore.Http;

namespace Database_FizzBuzz_dotNET
{
    public class IndexModel : PageModel
    {
        public FizzbuzzContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, FizzbuzzContext context)
        {
            _logger = logger;
            _context = context;
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

                _context.FizzBuzz.Add(fizzbuzz);
                _context.SaveChanges();

                return Page();
            }
        }
    }
}
