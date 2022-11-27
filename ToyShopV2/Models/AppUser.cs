using Microsoft.AspNetCore.Identity;

namespace ToyShopV2.Models
{
    public class AppUser : IdentityUser
    {
        public string? Occupation { get; set; } = "Test";
    }
}
