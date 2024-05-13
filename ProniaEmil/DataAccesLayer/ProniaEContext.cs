using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProniaEmil.Models;
using ProniaEmil.ViewModels.Categories;

namespace ProniaEmil.DataAccesLayer
{
    public class ProniaEContext : DbContext
    {
        public ProniaEContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-742DB1G;Database=EMILPRONIA;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(options);
        }
        public DbSet<ProniaEmil.ViewModels.Categories.GetCategoryVM> GetCategoryVM { get; set; } = default!;
    }
}
