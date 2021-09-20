using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ProductServer.Models
{
  public class ProductContext : DbContext
  {
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      // Seed(builder);

    }

    private void Seed(ModelBuilder builder)
    {
      Dictionary<string, List<string>> mocks = null;
      using (StreamReader reader = new StreamReader("Mocks/products.json"))
      {
        string json = reader.ReadToEnd();
        mocks = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
      }

      List<string> uuids = null;
      using (StreamReader reader = new StreamReader("Mocks/uuids.json"))
      {
        string json = reader.ReadToEnd();
        uuids = JsonConvert.DeserializeObject<List<string>>(json);
      }

      // map each category in products.json to its corresponding index in Categories list
      var map = new Dictionary<string, int>()
      {
        {"books", 0},
        {"cars", 1},
        {"tvs", 2},
        {"laptops", 3},
        {"phones", 4},
      };

      int uuidCounter = 0;
      User[] users = new User[]
      {
        new User { ID = new Guid(uuids[uuidCounter++]), DisplayName = "Tuan Nguyen", HashedPassword = "$2a$13$xk2HTLFXnufoUgKKDrNeL.pT.6o.3tBcpQcfztHuIQ4Umyokg6.7a" }
      };
      builder.Entity<User>().HasData(users);

      Supplier[] suppliers = new Supplier[] {
        new Supplier { ID = new Guid(uuids[uuidCounter++]), Name = "Alpha", Address = "Ho Chi Minh City" },
        new Supplier { ID = new Guid(uuids[uuidCounter++]), Name = "Beta", Address = "Ha Noi City" },
        new Supplier { ID = new Guid(uuids[uuidCounter++]), Name = "Delta", Address = "Da Nang City" }
       };
      builder.Entity<Supplier>().HasData(suppliers);

      Category[] categories = new Category[] {
        new Category { ID = new Guid(uuids[uuidCounter++]), Name = "Book" },
        new Category { ID = new Guid(uuids[uuidCounter++]), Name = "Car" },
        new Category { ID = new Guid(uuids[uuidCounter++]), Name = "Television" },
        new Category { ID = new Guid(uuids[uuidCounter++]), Name = "Laptop" },
        new Category { ID = new Guid(uuids[uuidCounter++]), Name = "Mobile Phone" }
       };
      builder.Entity<Category>().HasData(categories);

      Random random = new Random(1);
      List<Product> products = new List<Product>(100);
      List<Dictionary<string, object>> prodcutsCategories = new List<Dictionary<string, object>>();
      List<ProductDetail> productDetails = new List<ProductDetail>(100);
      foreach (var category in mocks.Keys)
      {
        foreach (var name in mocks[category])
        {
          Guid id = new Guid(uuids[uuidCounter++]);
          products.Add(new Product
          {
            ID = id,
            Name = name,
            Description = "product's short description",
            Rating = (short)random.Next(0, 5),
            Price = random.NextDouble() * 1000,
            SupplierID = suppliers[random.Next(0, suppliers.Length)].ID,
            ReleaseDate = DateTime.UtcNow.AddDays(random.NextDouble() * 3600 - 1800),
          });
          prodcutsCategories.Add(new Dictionary<string, object>()
          {
            {"ProductsID", id},
            {"CategoriesID", categories[map[category]].ID}
          });
          productDetails.Add(new ProductDetail
          {
            ProductID = id,
            Detail = "Cum facere tenetur aut cupiditate sint qui explicabo consequatur et possimus velit. Hic consequuntur labore in velit dolores et iusto autem vel provident. Eum voluptatem quos qui iste pariatur aut consequatur reprehenderit ad fugiat ipsum. Qui vitae veritatis quo nesciunt itaque sed dolorem aperiam ab quod quisquam ut tempora officia. "
          });
        }
      }
      builder.Entity<Product>().HasData(products);
      builder.Entity<ProductDetail>().HasData(productDetails);
      builder.Entity("CategoryProduct").HasData(prodcutsCategories);

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<User> Users { get; set; }
  }

}
