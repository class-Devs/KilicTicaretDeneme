using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) :
        base(contextOptions)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
}