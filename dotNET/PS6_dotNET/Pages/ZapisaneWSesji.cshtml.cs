using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PS6_dotNET.Models;

namespace PS6_dotNET.Pages
{
    public class FizzBuzzModel : PageModel
    {
        public FizzBuzz fizzbuzz { get; set; }
        public void OnGet()
        {
            var result = HttpContext.Session.GetString("Wynik");

            if (result != null) 
            {
                fizzbuzz = JsonConvert.DeserializeObject<FizzBuzz>(result);
            };
        }
    }
}
