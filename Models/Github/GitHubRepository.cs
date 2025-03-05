namespace REST_API_ResumeHandler.Models.GitHub
{
    public class GitHubRepository
    {
        public string Name { get; set; }
        public string? Language { get; set; }
        public string? Description { get; set; }
        public string HtmlUrl { get; set; }
    }
}