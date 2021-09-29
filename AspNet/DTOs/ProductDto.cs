using System;
using System.Collections.Generic;
using System.Linq;
using ProductServer.Models;

namespace ProductServer.DTOs
{
  public class ProductDetailDto
  {
    public ProductDetailDto() { }
    public ProductDetailDto(IProduct product)
    {
      this.Name = product.Name;
      this.Id = product.ID;
      this.Supplier = product.Supplier;
      this.Description = product.Description;
      this.ReleasedDate = product.ReleaseDate;
      this.Rating = product.Rating;
      this.Price = product.Price;
      this.DiscontinuedDate = product.DiscontinuedDate;
      this.Categories = product.Categories.ToList();
      this.Detail = product.ProductDetail?.Detail;
    }

    public string Name { get; set; }
    public Guid Id { get; set; }
    public Supplier Supplier { get; set; }
    public string Description { get; set; }
    public DateTime ReleasedDate { get; set; }
    public short Rating { get; set; }
    public double Price { get; set; }
    public List<Category> Categories { get; set; }
    public DateTime? DiscontinuedDate { get; set; }
    public string Detail { get; set; }
  }
  public class ProductMasterDto
  {
    public ProductMasterDto() { }
    public ProductMasterDto(IProduct product)
    {
      this.Name = product.Name;
      this.Id = product.ID;
      this.Supplier = product.Supplier.Name;
      this.Rating = product.Rating;
      this.Price = product.Price;
      this.Categories = product.Categories.Select(c => c.Name).ToList();
    }

    public string Name { get; set; }
    public Guid Id { get; set; }
    public string Supplier { get; set; }
    public short Rating { get; set; }
    public double Price { get; set; }
    public List<string> Categories { get; set; }
  }

  public class PaginationDto<T> where T : class
  {
    public IEnumerable<T> Items { get; set; }

    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int PageOffset { get; set; }
  }

}