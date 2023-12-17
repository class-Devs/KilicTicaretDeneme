using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Model;

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ApplicationDbContext _context;
    public List<Product> Products { get; set; }

    public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public void OnGet()
    {
        Products = GetProducts().Result;
    }

    public async Task<List<Product>> GetProducts()
    {
        var productsGetAll = await _context.Products.ToListAsync();
        return productsGetAll;
    }
    
    // private List<Product> GetSampleProducts()
    // {
    //     // Örnek ürünleri oluşturun (gerçek uygulamada bir veritabanından alınmalıdır)
    //     return new List<Product>
    //     {
    //         new ProductModel { Name = "Ürün 1", Description = "Ürün 1 Açıklaması", Price = 10.99m, ImageUrl = "path-to-product-1.jpg" },
    //         new ProductModel { Name = "Ürün 2", Description = "Ürün 2 Açıklaması", Price = 19.99m, ImageUrl = "path-to-product-2.jpg" },
    //         new ProductModel { Name = "Ürün 1", Description = "Ürün 1 Açıklaması", Price = 10.99m, ImageUrl = "path-to-product-1.jpg" },
    //         new ProductModel { Name = "Ürün 2", Description = "Ürün 2 Açıklaması", Price = 19.99m, ImageUrl = "path-to-product-2.jpg" },
    //         new ProductModel { Name = "Ürün 1", Description = "Ürün 1 Açıklaması", Price = 10.99m, ImageUrl = "path-to-product-1.jpg" },
    //         new ProductModel { Name = "Ürün 2", Description = "Ürün 2 Açıklaması", Price = 19.99m, ImageUrl = "path-to-product-2.jpg" },
    //         new ProductModel { Name = "Ürün 1", Description = "Ürün 1 Açıklaması", Price = 10.99m, ImageUrl = "path-to-product-1.jpg" },
    //         new ProductModel { Name = "Ürün 2", Description = "Ürün 2 Açıklaması", Price = 19.99m, ImageUrl = "path-to-product-2.jpg" },
    //         new ProductModel { Name = "Ürün 1", Description = "Ürün 1 Açıklaması", Price = 10.99m, ImageUrl = "path-to-product-1.jpg" },
    //         new ProductModel { Name = "Ürün 2", Description = "Ürün 2 Açıklaması", Price = 19.99m, ImageUrl = "path-to-product-2.jpg" },
    //         new ProductModel { Name = "Ürün 1", Description = "Ürün 1 Açıklaması", Price = 10.99m, ImageUrl = "path-to-product-1.jpg" },
    //         new ProductModel { Name = "Ürün 2", Description = "Ürün 2 Açıklaması", Price = 19.99m, ImageUrl = "path-to-product-2.jpg" },
    //         new ProductModel { Name = "Ürün 1", Description = "Ürün 1 Açıklaması", Price = 10.99m, ImageUrl = "path-to-product-1.jpg" },
    //         new ProductModel { Name = "Ürün 2", Description = "Ürün 2 Açıklaması", Price = 19.99m, ImageUrl = "path-to-product-2.jpg" },
    //         // Diğer ürünleri ekleyin
    //     };
    // }
}