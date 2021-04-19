using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS6_dotNET.Data;
using PS6_dotNET.Models;
using PS6_dotNET.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PS6_dotNET.Pages
{
    public class PobraneZPlikuModel : PageModel
    {
        public JsonFileProductService ProductService { get; }
        public PobraneZPlikuModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public IEnumerable<Product> Products { get; private set; }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
