using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServer.Models
{
    public class ProductDetail
    {
        [Key]
        public Guid ProductID { get; set; }

        [Required]
        public string Detail { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }
    }
}
