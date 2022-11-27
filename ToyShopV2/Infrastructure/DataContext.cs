using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToyShopV2.Models;

namespace ToyShopV2.Infrastructure
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
            public DbSet<Toy>Toys { get; set; }
            public DbSet<Order>Orders { get; set; }
            public DbSet<Cart>Carts { get; set; }
    }
}
