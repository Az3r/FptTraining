using System;
using System.ComponentModel.DataAnnotations;

namespace ProductServer.ApiModels
{
    public class CreateUserRequest
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string DisplayName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }

    public class LoginRequest
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
