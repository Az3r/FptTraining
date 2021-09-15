using System;
using System.ComponentModel.DataAnnotations;

namespace ProductServer.Models
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(60)]
        public string HashedPassword { get; set; }
    }
}
