using System.ComponentModel.DataAnnotations;

namespace REST_API_ResumeHandler.DTOs.Education
{
    public class EducationDto
    {
        public int EducationId { get; set; }

        [Required(ErrorMessage = "A school name is required")]
        [StringLength(300, MinimumLength = 3)]
        public string School { get; set; }

        [Required(ErrorMessage = "A degree name is required")]
        [StringLength(300, MinimumLength = 3)]
        public string Degree { get; set; }

        [Required]
        [Range(1950, 2050, ErrorMessage = "Provide a valid year between 1950 och 2050")]
        public int StartYear { get; set; }

        [Range(1950, 2050, ErrorMessage = "Provide a valid year between 1950 och 2050")]
        public int? EndYear { get; set; }

        public int FKPersonId { get; set; }
    }
}