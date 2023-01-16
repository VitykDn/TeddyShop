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

            if (!context.ToyColors.Any())
            {

                context.ToyColors.AddRange(

                    new ToyColor() { Name = "Білий" },
                    new ToyColor() { Name = "Молочний" },
                    new ToyColor() { Name = "Сірий" },
                    new ToyColor() { Name = "Персиковий," },
                    new ToyColor() { Name = "Рижий" },
                    new ToyColor() { Name = "Жовтий" },
                    new ToyColor() { Name = "Рожевий" },
                    new ToyColor() { Name = "Червоний" },
                    new ToyColor() { Name = "Зелений" },
                    new ToyColor() { Name = "Коричневий" }

                );

                context.SaveChanges();
            }
        }
    }
}