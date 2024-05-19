using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProniaEmil.Models;
using ProniaEmil.ViewModels.Categories;

namespace ProniaEmil.DataAccesLayer
{
    public class ProniaEContext : IdentityDbContext
    {
        public ProniaEContext(DbContextOptions<ProniaEContext> options) : base(options)
        {
        }
        public DbSet <Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet <AppUser> AppUsers { get; set; }

      
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedTime = DateTime.Now;
                          entity.IsDeleted = false;
                            break;
                            //case EntityState.Modified:
                            //entity.UpdatedTime= DateTime.Now;
                            //break


                    }
                }

            };

            return base.SaveChangesAsync(cancellationToken);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Server=DESKTOP-742DB1G;Database=EMILPRONIA;Trusted_Connection=True;TrustServerCertificate=True;");
        //    base.OnConfiguring(options);
        //}
    }
}
