using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServer.Models
{
  public class Auth
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