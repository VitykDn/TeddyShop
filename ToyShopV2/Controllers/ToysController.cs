using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyShopV2.Infrastructure;

namespace ToyShopV2.Controllers
{
    public class ToysController : Controller
    {
        private readonly DataContext _context;
        public ToysController(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index(int p=1)
        {
            int PageSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = PageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Toys.Count() / PageSize);
            return View(await _context.Toys.OrderByDescending(p =>p.Id).ToListAsync());
            //return View(await _context.Toys.OrderByDescending(p =>p.Id).Skip((p-1) * PageSize).Take(PageSize).ToListAsync());
        }
    }
}
