using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PS3_dotNET.Models
{
    public class Address
    {
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Display(Name = "Miasto w którym mieszkasz")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Display(Name = "Twoja ulica")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Display(Name = "Numer domu")]
        public int Number { get; set; }

        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Display(Name = "Twój kod pocztowy")]
        public string ZipCode { get; set; }
    }
}
