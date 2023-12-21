using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Model;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; }
        public PaginatedList<Product> PaginatedProducts { get; set; }

        public IActionResult OnGetLoadMoreProducts(int pageIndex)
        {
            const int pageSize = 9;

            // Skip the products that have already been loaded
            var skippedProducts = _context.Products.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return Partial("_ProductListPartial", PaginatedList<Product>.Create(skippedProducts.AsQueryable(), pageIndex, pageSize));
        }



        // public IActionResult OnGet(int? pageIndex)
        // {
        //     const int pageSize = 9;
        //     
        //     // Veritabanından tüm ürünleri çek
        //     Products = _context.Products.ToList();
        //
        //     // Sayfalama için kullanılacak liste oluştur
        //     PaginatedProducts = PaginatedList<Product>.Create(Products.AsQueryable(), pageIndex ?? 1, pageSize);
        //
        //     return Page();
        // }
        public IActionResult OnGet(int? pageIndex)
        {
            const int pageSize = 9;

            // Veritabanından tüm ürünleri çek
            Products = _context.Products.ToList();

            // Sayfalama için kullanılacak liste oluştur
            PaginatedProducts = PaginatedList<Product>.Create(Products.AsQueryable(), pageIndex ?? 1, pageSize);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Partial("_ProductListPartial", PaginatedProducts);
            }

            return Page();
        }
    }
}