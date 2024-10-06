using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UserRegistrationApi.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name should be between 2 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password should be between 6 and 100 characters")]
        public string Password { get; set; } = string.Empty;

        public DateTime CreatedAt { get; private set; }

        // Método construtor
        public User()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}
