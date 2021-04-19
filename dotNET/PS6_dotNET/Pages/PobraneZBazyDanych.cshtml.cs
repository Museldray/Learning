using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PS6_dotNET.Data;
using PS6_dotNET.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PS6_dotNET.Pages
{
    public class PobraneZBazyDanychModel : PageModel
    {
        public ProductContext _context;

        public PobraneZBazyDanychModel(ProductContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }
    }
}
