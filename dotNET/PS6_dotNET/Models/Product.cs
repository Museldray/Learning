using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PS6_dotNET.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name = "Maker")]
        public string Maker { get; set; }
        [MaxLength(300)]
        [JsonPropertyName("img")]
        [Display(Name = "Image")]
        public string Image { get; set; }
        [MaxLength(300)]
        [Display(Name = "Url")]
        public string Url { get; set; }
        [MaxLength(100)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [MaxLength(300)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Product>(this);

 
    }
}