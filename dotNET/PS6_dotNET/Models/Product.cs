using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PS6_dotNET.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Display(Name = "Maker")]
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        [Display(Name = "Image")]
        public string Image { get; set; }
        [Display(Name = "Url")]
        public string Url { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Product>(this);

 
    }
}