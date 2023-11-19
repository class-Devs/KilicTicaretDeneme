using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public List<ProductModel> Products { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Products = GetSampleProducts();
    }
    
    private List<ProductModel> GetSampleProducts()
    {
        // Örnek ürünleri oluşturun (gerçek uygulamada bir veritabanından alınmalıdır)
        return new List<ProductModel>
        {
            new ProductModel { Name = "Ürün 1", Description = "Ürün 1 Açıklaması", Price = 10.99m, ImageUrl = "path-to-product-1.jpg" },
            new ProductModel { Name = "Ürün 2", Description = "Ürün 2 Açıklaması", Price = 19.99m, ImageUrl = "path-to-product-2.jpg" },
            // Diğer ürünleri ekleyin
        };
    }
}