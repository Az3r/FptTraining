using System;
using System.ComponentModel.DataAnnotations;

namespace ProductServer.Models
{
    public class Supplier
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
