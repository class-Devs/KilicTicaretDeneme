using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;

namespace WebApplication1.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(string searchText)
        {
            Console.WriteLine("deneme1");
            // Veritabanında arama yap
            var searchResults = _context.Products
                .Where(p => EF.Functions.Like(p.Name, "%" + searchText + "%"))
                .ToList();

            return Json(searchResults);
        }
    }
}