using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServer.Models
{
  public interface IAuth
  {
    string RefreshToken { get; set; }
    Guid UserID { get; set; }
    DateTime? ActivatedAt { get; set; }
    User User { get; set; }
  }

  public class Auth : IAuth
  {
    [Key]
    [MinLength(32)]
    [MaxLength(128)]
    public string RefreshToken { get; set; }
    public Guid UserID { get; set; }
    public DateTime? ActivatedAt { get; set; }
    public User User { get; set; }
  }

}