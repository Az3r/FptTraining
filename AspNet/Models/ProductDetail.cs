using System;
using System.ComponentModel.DataAnnotations;

namespace ProductServer.Models
{
    public class ProductDetail
    {
        [Key]
        public Guid ProductID { get; set; }
        public Product Product { get; set; }

        [Required]
        public string Detail { get; set; }

    }
}
