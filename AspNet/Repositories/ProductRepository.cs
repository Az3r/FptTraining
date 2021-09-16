using System;
using System.Collections.Generic;
using System.Linq;
using ProductServer.Models;

namespace ProductServer.Repositories
{
  public class ProductRepository : IDisposable
  {
    public ProductRepository(ProductContext context)
    {
      this.context = context;
    }

    public List<Product> FindProduct(ProductQuery query, int size = 20, int offset = 0)
    {
      if (query.IsEmpty())
      {
        return context.Products.Skip(offset * size).Take(size).ToList();
      }
      List<Product> products = context.Products.Where(p => p.Name.Equals(query.Name, StringComparison.InvariantCultureIgnoreCase)).ToList();
      return products;
    }

    public void Dispose()
    {
      context.Dispose();
    }

    private ProductContext context;
  }

  public class ProductQuery
  {
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public double MinPrice { get; set; } = double.MinValue;
    public double MaxPrice { get; set; } = double.MaxValue;

    public bool IsEmpty()
    {
      return (MaxPrice == double.MaxValue &&
              MinPrice == double.MinValue &&
              String.IsNullOrWhiteSpace(Name) &&
              String.IsNullOrWhiteSpace(Category));
    }
  }
}
