using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Context;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }
    
    // public IActionResult Details(int id)
    // {
    //     var product = _context.Products.FirstOrDefault(p => p.Id == id);
    //
    //     if (product == null)
    //     {
    //         return NotFound(); // 404 Not Found sayfasına yönlendirme
    //     }
    //
    //     return View(product);
    // }
    
    

}