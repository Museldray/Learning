using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz_dotNET.Models
{
    public class FizzBuzz
    {
        [Required]
        public int Id { get; set; }

        [Range(1, 1000)]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Display(Name = "Numer")]
        public int Number { get; set; }

        [Display(Name = "Result")]
        [MaxLengthAttribute(50)]
        public string Result { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string CheckResult(int number)
        {
            string result = "";

            if (number % 3 == 0)
            {
                result += "Fizz";
            }

            if (number % 5 == 0)
            {
                result += "Buzz";
            }

            if (result == "")
            {
                result = $"Liczba: {number} nie spełnia kryteriów Fizz/Buzz";
            }

            return result;
        }
    }
}
