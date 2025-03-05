using System.ComponentModel.DataAnnotations;

namespace REST_API_ResumeHandler.DTOs.Education
{
    // Base abstract class DTO with common properties
    // Range for a basic year validation
    public abstract class EducationBaseDto
    {
        [Required(ErrorMessage = "A school name is required")]
        [StringLength(300, MinimumLength = 3)]
        public string School { get; set; }

        [Required(ErrorMessage = "A degree name is required")]
        [StringLength(300, MinimumLength = 3)]
        public string Degree { get; set; }

        [Required]
        [Range(1950, 2050, ErrorMessage = "Provide a valid year between 1950 and 2050")]
        public int StartYear { get; set; }

        [Range(1950, 2050, ErrorMessage = "Provide a valid year between 1950 and 2050")]
        public int? EndYear { get; set; }
    }

    // Non-abstract class for public responses without IDs
    public class PublicEducationDto
    {
        public string School { get; set; }
        public string Degree { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
    }

    public class CreateEducationDto : EducationBaseDto
    {
        // Foreign key is required when creating education
        [Required]
        public int FKPersonId { get; set; }
    }

    public class UpdateEducationDto : EducationBaseDto
    {
        // Foreign key is required for validation purpose. Check if the referenced person exists
        [Required]
        public int FKPersonId { get; set; }
    }

    // DTO for responding with education data
    public class EducationResponseDto : EducationBaseDto
    {
        // Include ID and foreign key in responses
        public int EducationId { get; set; }

        public int FKPersonId { get; set; }
    }
}