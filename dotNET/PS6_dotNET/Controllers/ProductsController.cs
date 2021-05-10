using System.Collections.Generic;
using PS6_dotNET.Models;
using PS6_dotNET.Services;
using Microsoft.AspNetCore.Mvc;

namespace PS6_dotNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            return Ok();
        }

        public class RatingRequest
        {
            public int ProductId { get; set; }
        }
    }
}