using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Context;
using WebApplication1.Pages;

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
    
    public IActionResult Details(int productId)
    {
        var product = _context.Products.Find(productId);

        if (product == null)
        {
            return NotFound(); // Ürün bulunamazsa 404 hatası dönebilirsiniz.
        }

        return View(product);
    }
}