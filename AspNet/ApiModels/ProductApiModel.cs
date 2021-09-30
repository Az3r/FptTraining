using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProductServer.Models;

namespace ProductServer.ApiModels
{
  public class CreateProductRequest
  {
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public DateTime ReleasedDate { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public Guid SupplierId { get; set; }

    [Required]
    public List<Guid> CategoryIds { get; set; }
  }

  public class UpdateProductRequest
  {
    [MaxLength(200)]
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public DateTime ReleasedDate { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public Guid SupplierId { get; set; }

    [Required]
    public List<Guid> CategoryIds { get; set; }

    [Required]
    public string Detail { get; set; }

    public DateTime? DiscontinuedDate { get; set; }
  }
  public class FindProductRequest
  {
    public string Name { get; set; } = "";
    public List<Guid> Categories { get; set; } = new List<Guid>();
    public double MinPrice { get; set; } = double.MinValue;
    public double MaxPrice { get; set; } = double.MaxValue;
    public int Size { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string Sort { get; set; } = "name:asc,id:asc";
  }

}
