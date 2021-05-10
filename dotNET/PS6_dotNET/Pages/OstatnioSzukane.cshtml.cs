using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PS6_dotNET.Models;
using PS6_dotNET.Data;
using Microsoft.EntityFrameworkCore;

namespace PS6_dotNET.Pages
{
    public class OstatnioSzukaneModel : PageModel
    {
        private readonly FizzbuzzContext _context;

        public OstatnioSzukaneModel(FizzbuzzContext context)
        {
            _context = context;
        }

        public IList<Product> products { get; set; }

        public void OnGet()
        {
            var FizzbuzzQuery = from FizzBuzz in _context.FizzBuzz orderby FizzBuzz.Date descending select FizzBuzz;
            products = FizzbuzzQuery.Take(10).ToList();
        }
    }
}
