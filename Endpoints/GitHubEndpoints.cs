using REST_API_ResumeHandler.Models.GitHub;
using System.Text.Json;

namespace REST_API_ResumeHandler.Endpoints
{
    public static class GitHubEndpoints
    {
        public static WebApplication MapGitHubEndpoints(this WebApplication app)
        {
            // Fetch GitHub repositories for a specific username
            app.MapGet("/api/github/{username}", async (string username) =>
            {
                // Validate username input
                if (string.IsNullOrWhiteSpace(username))
                {
                    // Statuscode: 400 Bad Request
                    return Results.BadRequest("GitHub username cannot be empty");
                }

                // Create HTTP client with required headers for GitHub API
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "REST-API-ResumeHandler");

                // Make async request to GitHub API for user repositories
                var response = await client.GetAsync($"https://api.github.com/users/{username}/repos");

                // Handle case where user is not found or API returns error
                if (!response.IsSuccessStatusCode)
                {
                    // Return 404 Not Found with descriptive message
                    return Results.NotFound($"No repositories found for GitHub user '{username}' or user does not exist");
                }

                // Parse JSON response from GitHub API
                var content = await response.Content.ReadAsStringAsync();
                var repositories = JsonSerializer.Deserialize<List<GitHubRepository>>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // Handle case where user has no repositories
                if (repositories == null || !repositories.Any())
                {
                    // Statuscode: 404 Not Found
                    return Results.NotFound($"No repositories found for GitHub user '{username}'");
                }

                // Statuscode: 200 OK
                return Results.Ok(repositories);
            });

            return app;
        }
    }
}