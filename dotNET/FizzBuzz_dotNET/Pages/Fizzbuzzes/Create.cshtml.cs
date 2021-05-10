using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FizzBuzz_dotNET.Data;
using FizzBuzz_dotNET.Models;

namespace FizzBuzz_dotNET.Pages.Fizzbuzzes
{
    public class CreateModel : PageModel
    {
        private readonly FizzBuzz_dotNET.Data.FizzbuzzContext _context;

        public CreateModel(FizzBuzz_dotNET.Data.FizzbuzzContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            FizzBuzz.Email = User.Identity.Name;

            _context.FizzBuzz.Add(FizzBuzz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
