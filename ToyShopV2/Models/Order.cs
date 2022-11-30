using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToyShopV2.Models.ViewModels;

namespace ToyShopV2.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        
        public decimal OrderPrice { get; set; }

        public string? Comment { get; set; }
        
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [ValidateNever]
        public List<OrderDetail>? OrderDetails { get; set; }

    }
}
