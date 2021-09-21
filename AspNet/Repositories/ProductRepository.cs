using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductServer.DTOs;
using ProductServer.Models;

namespace ProductServer.Repositories
{
  public class ProductRepository : GenericRepository<Product>
  {
    public ProductRepository(ProductContext context) : base(context) { }

    public IEnumerable<Product> GetAll()
    {
      var products = Entities
      .Include(p => p.Supplier)
      .Include(p => p.Categories)
      .AsNoTracking()
      .Select(p => new Product
      {
        ID = p.ID,
        Name = p.Name,
        Price = p.Price,
        Rating = p.Rating,
        Supplier = new Supplier { Name = p.Supplier.Name },
        Categories = p.Categories.Select(c => new Category { Name = c.Name })
      })
      .AsEnumerable();

      return products;
    }

    public Product GetProduct(Guid id)
    {
      var product = Entities
      .Include(p => p.ProductDetail)
      .Include(p => p.Categories)
      .Include(p => p.Supplier)
      .AsNoTracking()
      .Single(p => p.ID.Equals(id));

      return product;
    }
  }
}