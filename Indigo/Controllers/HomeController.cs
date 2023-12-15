using Indigo.DAL;
using Indigo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Indigo.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //HomeVM homeVM = new HomeVM();

            List<Product> products = _context.Products.ToList();
            return View(products);
        }
    }
}
