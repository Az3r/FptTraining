using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServer.Models
{
  public interface IProductDetail
  {
    Guid ProductID { get; set; }
    string Detail { get; set; }
  }

  public class ProductDetail : IProductDetail
  {
    [Key]
    public Guid ProductID { get; set; }

    [Required]
    public string Detail { get; set; }
  }

}
