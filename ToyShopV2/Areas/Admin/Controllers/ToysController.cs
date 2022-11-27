using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToyShopV2.Infrastructure;
using ToyShopV2.Models;

namespace ToyShopV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ToysController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ToysController(DataContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnvironment = webHostEnviroment;
        }

        public async Task<ActionResult> Index(int p = 1)
        {
            int PageSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = PageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Toys.Count() / PageSize);
            return View(await _context.Toys.OrderByDescending(p => p.Id)
                .Skip((p - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync());
            // return View(await _context.Toys.OrderByDescending(p => p.Id).ToListAsync());

        }
        public  ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Toy toy)
        {
            

            if (ModelState.IsValid)
            {
                               


                if (toy.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/toys");
                    string imageName = Guid.NewGuid().ToString() + "_" + toy.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await toy.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    toy.Image = imageName;
                }

                _context.Add(toy);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The product has been created!";

                return RedirectToAction("Index");
            }

            return View(toy);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Toy product = await _context.Toys.FindAsync(id);

            

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Toy toy)
        {
            


                if (toy.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/toys");
                    string imageName = Guid.NewGuid().ToString() + "_" + toy.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await toy.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    toy.Image = imageName;
                }

                _context.Update(toy);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The product has been edited!";
                return View(toy);
            }

 

        public async Task<IActionResult> Delete(int id)
        {
            Toy toy = await _context.Toys.FindAsync(id);

            if (!string.Equals(toy.Image, "noimage.png"))
            {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/toys");
                string oldImagePath = Path.Combine(uploadsDir, toy.Image);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _context.Toys.Remove(toy);
            await _context.SaveChangesAsync();

            TempData["Success"] = "The product has been deleted!";

            return RedirectToAction("Index");
        }


    }
}
