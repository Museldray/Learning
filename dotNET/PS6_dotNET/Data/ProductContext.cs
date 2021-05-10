using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS6_dotNET.Models;
using Microsoft.EntityFrameworkCore;


namespace PS6_dotNET.Data
{
    public class FizzbuzzContext : DbContext
    {
        public DbSet<Product> FizzBuzz { get; set; }

        public FizzbuzzContext(DbContextOptions options) : base(options) { }
    }
}
