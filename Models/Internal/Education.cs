using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_ResumeHandler.Models.Internal
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }

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

        // Foreign key

        [ForeignKey("Person")]
        public int FKPersonId { get; set; }

        // Navigation property
        public Person Person { get; set; }
    }
}