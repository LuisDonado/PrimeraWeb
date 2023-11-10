using Microsoft.EntityFrameworkCore;
using PrimeraWeb.Models;

namespace PrimeraWeb.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
