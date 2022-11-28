using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DetailsPurchases> DetailsPurchases { get; set; }
        public DbSet<FinalProject.Models.ForDisplayingOnly> ForDisplayingOnly { get; set; }
    }
}
