using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServer.Models
{
  public interface IAuth
  {
    string Token { get; set; }
    Guid UserID { get; set; }
    DateTime ExpirationTime { get; set; }
    DateTime? ActivatedAt { get; set; }
    User User { get; set; }
  }

  public class Auth : IAuth
  {
    [Key]
    [StringLength(128)]
    public string Token { get; set; }
    public Guid UserID { get; set; }
    public DateTime ExpirationTime { get; set; }
    public DateTime? ActivatedAt { get; set; }
    public User User { get; set; }
  }

}