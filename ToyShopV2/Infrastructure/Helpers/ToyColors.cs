using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Drawing;
using ToyShopV2.Infrastructure.Helpers;
using ToyShopV2.Models;

namespace ToyShopV2.Infrastructure.Helpers
{
    public static class ToyColors
    {
        public static List<ToyColor> GetAll()
        {
            return new List<ToyColor>
                
            {
                new ToyColor() { Id = 1, Name = "Білий" },
                new ToyColor() { Id = 2, Name = "Молочний" },
                new ToyColor { Id = 3, Name = "Сірий" },
                new ToyColor { Id = 4, Name = "Персиковий," },
                new ToyColor { Id = 5, Name = "Рижий" },
                new ToyColor { Id = 6, Name = "Жовтий" },
                new ToyColor { Id = 7, Name = "Рожевий" },
                new ToyColor { Id = 8, Name = "Червоний" },
                new ToyColor { Id = 9, Name = "Зелений" },
                new ToyColor { Id = 10, Name = "Коричневий" },
            };
        }
        
    }
}
