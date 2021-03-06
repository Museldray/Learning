using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PS3_dotNET.Models;

namespace PS3_dotNET.Pages
{
    public class AddressModel : PageModel
    {
        public Address address { get; set; }
        public string result { get; set; }
        public void OnGet()
        {
            var SessionAddress = HttpContext.Session.GetString("SessionAddress");
            var Liczba = HttpContext.Session.GetInt32("Liczba");

            if (SessionAddress != null) 
            {
                address = JsonConvert.DeserializeObject<Address>(SessionAddress);
            };
            if (Liczba != null)
            {
                if(Liczba % 5 == 0)
                {
                    result = "Fizz";
                }
                else
                {
                    result = "Buzz";
                }
            }
        }
    }
}
