using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS6_dotNET.Models;
using Microsoft.EntityFrameworkCore;


namespace PS6_dotNET.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions options) : base(options) { }
    }
}
