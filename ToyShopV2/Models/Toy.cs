using ToyShopV2.Infrastructure.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToyShopV2.Models
{
    public class Toy
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введіть назву іграшки")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введіть розмір іграшки")]
        public string Size { get; set; }
        public string Color { get; set; }
        //[NotMapped]
        //public List<string> SelectedColors { get; set; }
        //public List<ToyColor> ToyColors { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Введіть ціну")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public string Image { get; set; } = "noimage.png";
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }

    }
}
