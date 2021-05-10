using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FizzBuzz_dotNET.Models;
using FizzBuzz_dotNET.Data;
using Microsoft.AspNetCore.Http;

namespace FizzBuzz_dotNET
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

                if(User.Identity.Name == null)
                {
                    return Page();
                }
                else
                {
                    fizzbuzz.Date = DateTime.Now;
                    fizzbuzz.Email = User.Identity.Name;
                    HttpContext.Session.SetString("Wynik", JsonConvert.SerializeObject(fizzbuzz));

                    _context.FizzBuzz.Add(fizzbuzz);
                    _context.SaveChanges();
                }

                return Page();
            }
        }
    }
}
