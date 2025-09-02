using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        public User() => Orders = new List<Order>();

        public int Id { get; set; }

        [Required, StringLength(100)]
        public required string FirstName { get; set; }

        [Required, StringLength(100)]
        public required string LastName { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string PasswordHash { get; set; }

        public required string PhoneNumber { get; set; }

        [Required, StringLength(50)]
        public required string Role { get; set; }

        public required ICollection<Order> Orders { get; set; }
    }
}
