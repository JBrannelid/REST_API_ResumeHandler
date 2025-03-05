using System.ComponentModel.DataAnnotations;

namespace REST_API_ResumeHandler.Models
{
    public class Person
    {
        [Key]
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
        public string EmailAddress { get; set; }

        // Regex: Validates Swedish phone number format (+46XXXXXXXXX or 0XXXXXXXXX)
        [RegularExpression(@"^(\+46|0)[0-9]{9}$", ErrorMessage = "Please provide a valid mobile number")]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(500, MinimumLength = 3)]
        public string? Description { get; set; }

        // Navigation properties
        public List<Education> Educations { get; set; }

        public List<Experience> Experiences { get; set; }
    }
}