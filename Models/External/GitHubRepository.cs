namespace REST_API_ResumeHandler.Models.GitHub
{
    public class GitHubRepository
    {
        // We decide which data we want to get from the API
        // Should match in name and type with what we get from the external API
        public string Name { get; set; }
        public string? Language { get; set; }
        public string? Description { get; set; }
        public string HtmlUrl { get; set; }
    }
}