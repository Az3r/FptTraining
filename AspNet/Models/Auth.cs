using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServer.Models
{
  public interface IAuth
  {
    Guid UserID { get; set; }
    User User { get; set; }
    string RefreshToken { get; set; }
    DateTime? ActivatedAt { get; set; }
  }

  public class Auth : IAuth
  {
    public Guid UserID { get; set; }

    [ForeignKey("UserID")]
    public User User { get; set; }

    [Required]
    [StringLength(128)]
    public string RefreshToken { get; set; }

    public DateTime? ActivatedAt { get; set; }
  }

}