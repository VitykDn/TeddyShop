using Microsoft.EntityFrameworkCore;
using ToyShopV2.Models;
using ToyShopV2.Infrastructure;

namespace ToyShopV2.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            if (!context.Toys.Any())
            {
               

                context.Toys.AddRange(
                        new Toy
                        {
                            Name = "Test",
                            Size = "120",
                            Price = 1.50M,
                            Color = "Red",
                            Image = "test.jpg"
                        },
                        new Toy
                        {
                            Name = "Heart",
                            Size = "new",
                            Price = 21.50M,
                            Color = "Blue",
                            Image = "test2.jpg"
                        },
                        new Toy
                        {
                            Name = "Test3",
                            Size = "120",
                            Price = 1.50M,
                            Color = "Red",
                            Image = "test.jpg"
                        },
                        new Toy
                        {
                            Name = "Heart4",
                            Size = "new",
                            Price = 21.50M,
                            Color = "Blue",
                            Image = "test2.jpg"
                        }
                );

                context.SaveChanges();
            }
        }
    }
}