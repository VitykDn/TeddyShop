﻿using System.ComponentModel.DataAnnotations;

namespace ToyShopV2.Infrastructure.Validation
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);

                string[] extensions = { "jpg", "png" };
                bool result = extensions.Any(x => extension.EndsWith(x));

                if (!result)
                {
                    return new ValidationResult("Дозволені фориати: jpg і png");
                }
            }

            return ValidationResult.Success;
        }
    }
}