using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzz_dotNET.Data;
using FizzBuzz_dotNET.Models;
using Microsoft.AspNetCore.Authorization;

namespace FizzBuzz_dotNET.Pages.Fizzbuzzes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FizzBuzz_dotNET.Data.FizzbuzzContext _context;

        public IndexModel(FizzBuzz_dotNET.Data.FizzbuzzContext context)
        {
            _context = context;
        }

        public IList<FizzBuzz> FizzBuzz { get;set; }

        public async Task OnGetAsync()
        {
            var FizzbuzzQuery = from FizzBuzz in _context.FizzBuzz orderby FizzBuzz.Date descending select FizzBuzz;
            FizzBuzz = await FizzbuzzQuery.Take(10).ToListAsync();
        }
    }
}
