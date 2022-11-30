using Microsoft.AspNetCore.Mvc;
using ToyShopV2.Infrastructure;
using ToyShopV2.Models;
using ToyShopV2.Models.ViewModels;

namespace ToyShopV2.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;
        public CartController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVM);
        }
        public async Task<IActionResult> Add(int id)
        {
            Toy product = await _context.Toys.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(c => c.ToyId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "The product has been added!";

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> Decrease(int id)
        {
            

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(c => c.ToyId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "The product has been decreased!";

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(p => p.ToyId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index", "Toys");
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index", "Toys");
        }
       
    }
}
