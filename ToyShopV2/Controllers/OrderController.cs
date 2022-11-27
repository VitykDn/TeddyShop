using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToyShopV2.Infrastructure;
using ToyShopV2.Models.ViewModels;
using ToyShopV2.Models;
using Microsoft.AspNetCore.Hosting;

namespace ToyShopV2.Controllers
{
    public class OrderController : Controller
    {
        private readonly DataContext _context;
        public OrderController(DataContext context)
        {
            _context = context;
        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order, Cart cart)
        {
            
            if (ModelState.IsValid)
            {



               
                _context.Add(order);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The product has been created!";

                return RedirectToAction("Index", "Toys");
            }

            return View(order);
        }
    }
}
