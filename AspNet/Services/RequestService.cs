using System;
using System.Linq;
using ProductServer.ApiModels;
using ProductServer.Models;

namespace ProductServer.Services
{
  public interface IRequestService
  {
    Product ToProduct(CreateProductRequest request);
    Product ToProduct(Guid id, UpdateProductRequest request);
  }

  public class RequestService : IRequestService
  {
    public Product ToProduct(CreateProductRequest request)
    {
      return new Product
      {
        Name = request.Name,
        ReleaseDate = request.ReleaseDate,
        Categories = request.CategoryIds.Select(id => new Category { ID = id }),
        SupplierID = request.SupplierId,
        Description = request.Description,
        Price = request.Price
      };
    }

    public Product ToProduct(Guid id, UpdateProductRequest request)
    {
      return new Product
      {
        ID = id,
        Name = request.Name,
        Categories = request.CategoryIds.Select(id => new Category { ID = id }),
        SupplierID = request.SupplierId,
        Description = request.Description,
        Price = request.Price,
        DiscontinuedDate = request.DiscontinuedDate,
        ProductDetail = new ProductDetail { ProductID = id, Detail = request.Detail }
      };
    }
  }
}