using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_FizzBuzz_dotNET.Models;
using Microsoft.EntityFrameworkCore;


namespace Database_FizzBuzz_dotNET
{
    public class FizzbuzzContext
    {
        public DbSet<FizzBuzz> FizzBuzz { get; set; }
    }
}
