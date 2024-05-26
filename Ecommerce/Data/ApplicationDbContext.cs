using Ecommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Product>? Products { get; set; }
    public DbSet<ProductType>? ProductTypes { get; set; }
    public DbSet<ProductBrand>? ProductBrands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
                    .HasOne(p => p.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.ProductTypeId);

        modelBuilder.Entity<Product>()
                    .HasOne(p => p.ProductBrand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.ProductBrandId);
    }
}
