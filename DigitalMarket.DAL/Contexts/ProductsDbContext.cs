using DigitalMarket.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalMarket.DAL.Contexts
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        public ProductsDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}