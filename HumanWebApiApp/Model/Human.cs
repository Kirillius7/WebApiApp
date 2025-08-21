using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HumanWebApiApp.Model
{
    public class Human
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(maximumLength: 15, MinimumLength = 2, ErrorMessage = "Range")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Second Name is required")]
        [StringLength(maximumLength: 15, MinimumLength = 2, ErrorMessage = "Range")]
        public string secondName { get; set; }

        [Required(ErrorMessage = "Citizenship is required")]
        [StringLength(maximumLength: 15, MinimumLength = 2, ErrorMessage = "Range")]
        public string citizenship { get; set; }

        [Required(ErrorMessage = "EmailAddress is required")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [PasswordPropertyText]
        public string password { get; set; }
    }

    class ErrorResponse
    {
        public string Error { get; set; }
        public string Details { get; set; }
    }
}
