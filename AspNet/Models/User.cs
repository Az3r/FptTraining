using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductServer.Models
{
  public interface IUser
  {
    Guid ID { get; set; }
    string DisplayName { get; set; }
    string HashedPassword { get; set; }
    List<Auth> Auths { get; set; }
  }

  public class User : IUser
  {
    [Key]
    public Guid ID { get; set; }

    [Required]
    [MaxLength(100)]
    public string DisplayName { get; set; }

    [Required]
    [StringLength(60)]
    public string HashedPassword { get; set; }

    public List<Auth> Auths { get; set; }
  }
}
