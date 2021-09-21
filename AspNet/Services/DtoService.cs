using System.Collections.Generic;
using System.Linq;
using ProductServer.DTOs;
using ProductServer.Models;

namespace ProductServer.Services
{
  public interface IDtoService
  {
    ProductDetailDto ToProductDetail(IProduct product);
    List<ProductMasterDto> ToProductMaster(IEnumerable<IProduct> products);
  }

  public class DtoService : IDtoService
  {
    public List<ProductMasterDto> ToProductMaster(IEnumerable<IProduct> products)
    {
      return products.Select(p => new ProductMasterDto(p)).ToList();
    }

    public ProductDetailDto ToProductDetail(IProduct product)
    {
      return new ProductDetailDto(product);
    }
  }
}