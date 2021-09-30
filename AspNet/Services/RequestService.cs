using System;
using System.Linq;
using ProductServer.ApiModels;
using ProductServer.Models;
using ProductServer.Repositories;

namespace ProductServer.Services
{
  public interface IRequestService
  {
    Product ToProduct(CreateProductRequest request);
    Product ToProduct(Guid id, UpdateProductRequest request);
    ProductFilter ToProductFilter(FindProductRequest request);
    ProductOrder ToProductOrder(FindProductRequest request);
  }

  public class RequestService : IRequestService
  {
    public Product ToProduct(CreateProductRequest request)
    {
      return new Product
      {
        Name = request.Name,
        ReleaseDate = request.ReleasedDate,
        Categories = request.CategoryIds.Select(id => new Category { ID = id }).ToList(),
        SupplierID = request.SupplierId,
        Description = request.Description,
        Price = request.Price,
      };
    }

    public Product ToProduct(Guid id, UpdateProductRequest request)
    {
      return new Product
      {
        ID = id,
        Name = request.Name,
        ReleaseDate = request.ReleasedDate,
        Categories = request.CategoryIds.Select(id => new Category { ID = id }).ToList(),
        SupplierID = request.SupplierId,
        Description = request.Description,
        Price = request.Price,
        DiscontinuedDate = request.DiscontinuedDate,
        ProductDetail = new ProductDetail { ProductID = id, Detail = request.Detail }
      };
    }

    public ProductFilter ToProductFilter(FindProductRequest request)
    {
      return new ProductFilter
      {
        Name = request.Name,
        Categories = request.Categories,
        MinPrice = request.MinPrice,
        MaxPrice = request.MaxPrice
      };
    }

    public ProductOrder ToProductOrder(FindProductRequest request)
    {
      // ?sort=name:asc,price:desc
      // ["name:asc", "price:desc"]
      Console.WriteLine(request.Sort);
      string[] fields = request.Sort.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
      ProductOrder sort = new ProductOrder();

      foreach (string field in fields)
      {
        string[] options = field.Split(":", 2, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        switch (options[0])
        {
          case "name":
            {
              bool success = Enum.TryParse<OrderBy>(options[1], true, out OrderBy order);
              sort.Name = success ? order : OrderBy.ASC;
              break;
            }
          case "rating":
            {
              bool success = Enum.TryParse<OrderBy>(options[1], true, out OrderBy order);
              sort.Rating = success ? order : OrderBy.ASC;
              break;
            }
          case "price":
            {
              bool success = Enum.TryParse<OrderBy>(options[1], true, out OrderBy order);
              sort.Price = success ? order : OrderBy.ASC;
              break;
            }
        }
      }
      return sort;
    }

  }
}