using Microsoft.EntityFrameworkCore;

namespace ProductServer.Models
{
  public class ProductContext : DbContext
  {
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Auth>().HasKey(p => new { p.UserID, p.RefreshToken });
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<User> Users { get; set; }
  }

}
