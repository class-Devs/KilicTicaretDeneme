using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Context;
using WebApplication1.Model; // WebApplication1.Model isim alanını ekledik

namespace WebApplication1.Pages
{
    public class CartModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CartModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CartItem> CartItems { get; set; }

        public IActionResult OnGet()
        {
            var Cookie = Request.Headers.Cookie.ToString();
            var cartCookie = Cookie.Split('=').Last();
            List<CartItemInfo> cartItemInfos = JsonConvert.DeserializeObject<List<CartItemInfo>>(cartCookie);

            // Veritabanından ürün bilgilerini al ve CartItem oluştur
            CartItems = new List<CartItem>();
            foreach (var cartItemInfo in cartItemInfos)
            {
                Product product = _context.Products.Find(cartItemInfo.ProductId);
                if (product != null)
                {
                    CartItem cartItem = new CartItem
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Count = cartItemInfo.Count,
                        TotalPrice = cartItemInfo.Count * product.Price
                    };
                    CartItems.Add(cartItem);
                }
            }

            return Page();
        }

        // Bu sınıf, Cookie'den alınan bilgileri geçici olarak depolamak için kullanılır
        private class CartItemInfo
        {
            public int ProductId { get; set; }
            public int Count { get; set; }
        }
    }
}