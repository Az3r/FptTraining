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
      .SingleOrDefault(p => p.ID.Equals(id));

      return product;
    }

    public IEnumerable<Product> Find(ProductFilter filter, ProductOrder sort, int size, int offset)
    {
      Func<Product, bool> predicate = (product) =>
      {
        var categories = product.Categories.Select(c => c.Name).Intersect(filter.Category).ToList();
        return product.Name.Contains(filter.Name)
               && categories.Count == filter.Category.Count
               && product.Price >= filter.MinPrice
               && product.Price <= filter.MaxPrice;
      };

      IEnumerable<Product> MakeOrder(IEnumerable<Product> query)
      {
        var result = query;
        result = sort.Name == OrderBy.ASC ? result.OrderBy(p => p.Name) : result.OrderByDescending(p => p.Name);
        result = sort.Rating == OrderBy.ASC ? result.OrderBy(p => p.Rating) : result.OrderByDescending(p => p.Rating);
        result = sort.Price == OrderBy.ASC ? result.OrderBy(p => p.Price) : result.OrderByDescending(p => p.Price);
        return result;
      };


      var query = Entities
      .Include(p => p.Supplier)
      .Include(p => p.Categories)
      .Select(p => new Product
      {
        ID = p.ID,
        Name = p.Name,
        Price = p.Price,
        Rating = p.Rating,
        Supplier = new Supplier { Name = p.Supplier.Name },
        Categories = p.Categories.Select(c => new Category { Name = c.Name })
      })
      .AsNoTracking()
      .Where(predicate).Skip(size * offset).Take(size);

      var products = MakeOrder(query);
      return products;
    }

  }
  public class ProductFilter
  {
    public string Name { get; set; }
    public List<string> Category { get; set; }
    public double MinPrice { get; set; }
    public double MaxPrice { get; set; }
  }

  public class ProductOrder
  {
    public OrderBy Name { get; set; } = OrderBy.ASC;
    public OrderBy Price { get; set; } = OrderBy.ASC;
    public OrderBy Rating { get; set; } = OrderBy.ASC;

  }

  public enum OrderBy
  {
    ASC,
    DESC
  }
}