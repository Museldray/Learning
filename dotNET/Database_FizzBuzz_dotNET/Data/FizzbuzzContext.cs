using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_FizzBuzz_dotNET.Models;
using Microsoft.EntityFrameworkCore;


namespace Database_FizzBuzz_dotNET.Data
{
    public class FizzbuzzContext : DbContext
    {
        public DbSet<FizzBuzz> FizzBuzz { get; set; }

        public FizzbuzzContext(DbContextOptions options) : base(options) { }
    }
}
