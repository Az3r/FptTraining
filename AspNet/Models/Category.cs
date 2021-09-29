
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductServer.Models
{
  public class Category : ICategory, IEquatable<ICategory>
  {
    [Key]
    public Guid ID { get; set; }

    [MaxLength(200)]
    [Required]
    public string Name { get; set; }

    [JsonIgnore]
    public List<Product> Products { get; set; }

    public bool Equals(ICategory other)
    {
      return ID.Equals(other?.ID);
    }
  }

  public interface ICategory
  {
    Guid ID { get; set; }

    string Name { get; set; }

    [JsonIgnore]
    List<Product> Products { get; set; }
  }
}
