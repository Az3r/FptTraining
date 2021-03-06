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

    List<CategoryDto> ToCategory(IEnumerable<ICategory> categories);
    List<SupplierDto> ToSupplier(IEnumerable<ISupplier> suppliers);

    PaginationDto<T> ToPagination<T>(IEnumerable<T> items, int totalPages, int pageSize, int pageOffset) where T : class;
  }

  public class DtoService : IDtoService
  {
    public List<ProductMasterDto> ToProductMaster(IEnumerable<IProduct> products)
    {
      return products.Select(p => new ProductMasterDto(p)).ToList();
    }

    public PaginationDto<T> ToPagination<T>(IEnumerable<T> items, int totalPages, int pageSize, int pageOffset) where T : class
    {
      return new PaginationDto<T>
      {
        Items = items,
        TotalPages = totalPages,
        PageSize = pageSize,
        PageOffset = pageOffset
      };
    }

    public ProductDetailDto ToProductDetail(IProduct product)
    {
      return new ProductDetailDto(product);
    }

    public List<CategoryDto> ToCategory(IEnumerable<ICategory> categories)
    {
      return categories.Select(c => new CategoryDto
      {
        Id = c.ID,
        Name = c.Name
      }).ToList();
    }

    public List<SupplierDto> ToSupplier(IEnumerable<ISupplier> suppliers)
    {
      return suppliers.Select(c => new SupplierDto
      {
        Id = c.ID,
        Name = c.Name
      }).ToList();
    }
  }

}