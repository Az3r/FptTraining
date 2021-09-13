
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductServer.Models
{
    public class Category
    {
        [Key]
        public Guid ID { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
