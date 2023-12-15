using Indigo.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Indigo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
