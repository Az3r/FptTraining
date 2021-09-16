using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductServer.ApiModels
{
    public class CreateProductRequest
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public Guid SupplierId { get; set; }

        [Required]
        public List<Guid> CategoryIds { get; set; }

        public string Details { get; set; }
    }

    public class UpdateProductRequest
    {
        [Required]
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public double Price { get; set; }

        public Guid SupplierId { get; set; }

        public List<Guid> CategoryIds { get; set; }

        public string Details { get; set; }

        public DateTime? DiscontinuedDate { get; set; }
    }
}
