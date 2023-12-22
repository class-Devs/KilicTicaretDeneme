using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Model;

namespace WebApplication1.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Product? Product { get; set; }

        public IActionResult OnGet(int productId)
        {
            
            Product = _context.Products.Find(productId);
            
            if (Product == null)
            {
                return NotFound();
            }else
            {
                return Page();
            }

            
        }
    }

}