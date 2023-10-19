using NSwag.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UsersAPI.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(5)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Login is required")]
        [MinLength(5)]
        [MaxLength(40)]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6)]
        [MaxLength(30)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "Please, enter a valid email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(9)]
        [MaxLength(11)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "CPF is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF must contain 11 numbers.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The CPF must only contain numbers.")]
        public string? CPF { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Mother name is required")]
        [MinLength(5)]
        [MaxLength(100)]
        public string? MotherName { get; set; }
        public string? Status { get; set; }

        [Required(ErrorMessage = "Inclusion Date is required")]
        public DateTime InclusionDate { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
