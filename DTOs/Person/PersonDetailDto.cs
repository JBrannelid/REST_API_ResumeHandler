using REST_API_ResumeHandler.DTOs.Education;
using REST_API_ResumeHandler.DTOs.Experience;

namespace REST_API_ResumeHandler.DTOs.Person
{
    // No validation attributes needed as this is only used for outgoing (Response) data that has already been validated
    public class PersonDetailResponseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }

        public List<PublicEducationDto> Educations { get; set; } = new List<PublicEducationDto>();
        public List<PublicExperienceDto> Experiences { get; set; } = new List<PublicExperienceDto>();
    }
}