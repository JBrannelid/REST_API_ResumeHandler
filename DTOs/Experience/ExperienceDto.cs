using System.ComponentModel.DataAnnotations;

namespace REST_API_ResumeHandler.DTOs.Experience
{
    public class ExperienceDto
    {
        public int ExperienceId { get; set; }

        [Required(ErrorMessage = "A job title is required")]
        [StringLength(300, MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [StringLength(300, MinimumLength = 3)]
        public string Company { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [Range(1950, 2050, ErrorMessage = "Provide a valid year between 1950 och 2050")]
        public int StartYear { get; set; }

        [Range(1950, 2050, ErrorMessage = "Provide a valid year between 1950 och 2050")]
        public int? EndYear { get; set; }

        public int FKPersonId { get; set; }
    }
}