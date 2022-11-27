﻿using ToyShopV2.Infrastructure.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyShopV2.Models
{
    public class Toy
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        public string Name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public string Image { get; set; } = "noimage.png";
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }

    }
}
