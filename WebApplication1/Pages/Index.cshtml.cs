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
    public List<Model.Product> Products { get; set; }

    public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public void OnGet()
    {
        Products = GetProducts().Result;
    }

    public async Task<List<Model.Product>> GetProducts()
    {
        var productsGetAll = await _context.Products.ToListAsync();
        return productsGetAll;
    }
}