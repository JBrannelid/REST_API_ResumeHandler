using System.ComponentModel.DataAnnotations;

namespace REST_API_ResumeHandler.DTOs.Experience
{
    // Base abstract class DTO with common properties
    // Range for a basic year validation
    public abstract class ExperienceBaseDto
    {
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
        [Range(1950, 2050, ErrorMessage = "Provide a valid year between 1950 and 2050")]
        public int StartYear { get; set; }

        [Range(1950, 2050, ErrorMessage = "Provide a valid year between 1950 and 2050")]
        public int? EndYear { get; set; }
    }

    // Non-abstract class for public responses without IDs
    public class PublicExperienceDto
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
    }

    public class CreateExperienceDto : ExperienceBaseDto
    {
        // Foreign key is required when creating
        [Required]
        public int FKPersonId { get; set; }
    }

    public class UpdateExperienceDto : ExperienceBaseDto
    {
        // Foreign key is required for validation purpose. Check if the referenced person exists
        [Required]
        public int FKPersonId { get; set; }
    }

    public class ExperienceResponseDto : ExperienceBaseDto
    {
        // Include ID and foreign key in responses
        public int ExperienceId { get; set; }

        public int FKPersonId { get; set; }
    }
}