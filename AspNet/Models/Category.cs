
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductServer.Models
{
    public class Category : ICategory
    {
        [Key]
        public Guid ID { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }

    interface ICategory
    {
        Guid ID { get; set; }

        string Name { get; set; }

        List<Product> Products { get; set; }
    }
}
