using Indigo.Areas.Admin.ViewModel;
using Indigo.DAL;
using Indigo.Helpers;
using Indigo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Indigo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        AppDbContext _context;
        public ProductController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> product = await _context.Products.ToListAsync();
            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            List<Product> products = await _context.Products.ToListAsync();
            if(createProductVM is null)
            {
                return View("Error");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            Product product = new Product()
            {
                Title = createProductVM.Title,
                Description = createProductVM.Description,
                ImgUrl = createProductVM.ImgUrl,
                //ImgUrl = createProductVM.ImgUrl.Upload(_environment.WebRootPath, "/Upload/ProductImages/")
            };


            //if (!createProductVM.ImgUrl.CheckContent("image/"))
            //{
            //    ModelState.AddModelError("ImgUrl", "Invalid file format");
            //    return View();
            //}
            





            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Product");
        }


        public async Task<IActionResult> Update(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is null) 
            { 
                return View("Error"); 
            }
            UpdateProductVM updateProductVM = new UpdateProductVM()
            {
                id = id,
                Title = product.Title,
                Description = product.Description,
                ImageUrl = product.ImgUrl,
            };
            return View(updateProductVM);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVM updateProductVM)
        {
            Product existProduct = await _context.Products.FirstOrDefaultAsync();
            if(existProduct is null)
            {
                return View("Error");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            existProduct.Title = updateProductVM.Title;
            existProduct.Description = updateProductVM.Description;
            existProduct.ImgUrl = updateProductVM.ImageUrl;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }



        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if(product is null)
            {
                return View("Error");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
    }
}
