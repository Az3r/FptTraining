using System;
using System.ComponentModel.DataAnnotations;

namespace ProductServer.Models
{
  public interface ISupplier
  {
    Guid ID { get; set; }
    string Name { get; set; }
    string Address { get; set; }
  }

  public class Supplier : ISupplier
  {
    [Key]
    public Guid ID { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    [MaxLength(200)]
    [Required]
    public string Address { get; set; }
  }
}
