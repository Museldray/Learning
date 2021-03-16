using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz_dotNET.Models
{
    public class FizzBuzz
    {
        [Range(1, 1000)]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Display(Name = "Numer")]
        public int Number { get; set; }

        [Display(Name ="Result")]
        public string Result { get; set; }
    }
}
