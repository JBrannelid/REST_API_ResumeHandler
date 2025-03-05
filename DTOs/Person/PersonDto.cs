using REST_API_ResumeHandler.DTOs.Education;
using REST_API_ResumeHandler.DTOs.Experience;
using System.ComponentModel.DataAnnotations;

namespace REST_API_ResumeHandler.DTOs.Person
{
    public class PersonDto
    {
        public int PersonId { get; set; }

        [Required(ErrorMessage = "A first name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "A last name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "An email address is required")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please provide a valid email format")]
        [StringLength(100)]
        public string EmailAdress { get; set; }

        [RegularExpression(@"^(\+46|0)[0-9]{9}$", ErrorMessage = "Please provide a valid mobile number")]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(500, MinimumLength = 3)]
        public string? Description { get; set; }
    }
}