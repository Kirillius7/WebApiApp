using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HumanWebApiApp.DTO
{
    public class HumanCreateDTO
    {
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
}
