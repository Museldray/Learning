using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzz_dotNET.Models;
using FizzBuzz_dotNET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FizzBuzz_dotNET.Pages
{
    [Authorize]
    public class OstatnioSzukaneModel : PageModel
    {
        private readonly FizzbuzzContext _context;

        public OstatnioSzukaneModel(FizzbuzzContext context)
        {
            _context = context;
        }

        public IList<FizzBuzz> fizzBuzzes { get; set; }

        public void OnGet()
        {
            var FizzbuzzQuery = from FizzBuzz in _context.FizzBuzz orderby FizzBuzz.Date descending select FizzBuzz;
            fizzBuzzes = FizzbuzzQuery.Take(10).ToList();
        }
    }
}
