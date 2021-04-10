using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzz_dotNET.Data;
using FizzBuzz_dotNET.Models;

namespace FizzBuzz_dotNET.Pages.Fizzbuzzes
{
    public class DetailsModel : PageModel
    {
        private readonly FizzBuzz_dotNET.Data.FizzbuzzContext _context;

        public DetailsModel(FizzBuzz_dotNET.Data.FizzbuzzContext context)
        {
            _context = context;
        }

        public FizzBuzz FizzBuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzz.FirstOrDefaultAsync(m => m.Id == id);

            if (FizzBuzz == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
