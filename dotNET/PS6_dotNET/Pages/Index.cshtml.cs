using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS6_dotNET.Models;
using PS6_dotNET.Services;
using PS6_dotNET.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PS6_dotNET.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        public ProductContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService, ProductContext context)
        {
            _logger = logger;
            ProductService = productService;
            _context = context;
        }

        public JsonFileProductService ProductService { get; }
        public IEnumerable<Product> Products { get; private set; }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
