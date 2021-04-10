using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz_dotNET.Models;
using Microsoft.EntityFrameworkCore;


namespace FizzBuzz_dotNET.Data
{
    public class FizzbuzzContext : DbContext
    {
        public DbSet<FizzBuzz> FizzBuzz { get; set; }

        public FizzbuzzContext(DbContextOptions options) : base(options) { }
    }
}
