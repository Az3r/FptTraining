using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductServer.Models
{
  public interface IUser
  {
    Guid ID { get; set; }
    string DisplayName { get; set; }
    byte[] HashedPassword { get; set; }
    IEnumerable<Auth> Auths { get; set; }
  }

  public class User : IUser
  {
    [Key]
    public Guid ID { get; set; }

    [Required]
    [MaxLength(100)]
    public string DisplayName { get; set; }

    [Required]
    [MaxLength(64)]
    public byte[] HashedPassword { get; set; }

    [Required]
    [MaxLength(32)]
    public byte[] Salt { get; set; }

    public IEnumerable<Auth> Auths { get; set; }
  }
}
