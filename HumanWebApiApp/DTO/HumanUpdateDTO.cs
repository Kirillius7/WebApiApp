using System.ComponentModel.DataAnnotations;

namespace HumanWebApiApp.DTO
{
    public class HumanUpdateDTO
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
    }
}
