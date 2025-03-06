using REST_API_ResumeHandler.Models.GitHub;
using System.Text.Json;

namespace REST_API_ResumeHandler.Endpoints
{
    public static class GitHubEndpoints
    {
        public static WebApplication MapGitHubEndpoints(WebApplication app)
        {
            // Fetch GitHub repositories for a specific username
            app.MapGet("/api/github/{username}", async (string username, HttpClient client) =>
            {
                // GitHub API requires a User-Agent header for all requests
                client.DefaultRequestHeaders.Add("User-Agent", "request");

                // Get request to GitHub API for user repositories
                var response = await client.GetAsync($"https://api.github.com/users/{username}/repos");

                // If response status code is not 200
                if (!response.IsSuccessStatusCode)
                {
                    return Results.BadRequest("Request failed");
                }

                // Parse JSON response from GitHub API
                var json = await response.Content.ReadAsStringAsync(); // Fetch and store data as JSON string
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; // Ignore case sensitivity

                var data = JsonSerializer.Deserialize<List<GitHubRepository>>(json, options);

                // Remove null values from response
                foreach (var repo in data)
                {
                    // Remove null values from response
                    repo.Language ??= "Unknown language";
                    repo.Description ??= "No description provided";
                }

                // Return data
                return Results.Ok(data);
            });

            return app;
        }
    }
}


//// Post data to external API
//app.MapPost("JsonDataDemo", async (HttpClient client, TodoDTO todo) =>
//{
//    // Parse data to JSON string
//    var json = JsonSerializer.Serialize(todo); // Serialize TodoDTO object to JSON string

//    // Create object with JSON string
//    var content = new StringContent(json, Encoding.UTF8, "application/Json"); // Create content object with JSON string

//    // Post data to external API
//    var response = await client.PostAsync("https://jsonplaceholder.typicode.com/todos", content);

//    if (!response.IsSuccessStatusCode) // If response status code is not 200 
//    {
//        return Results.BadRequest("Failed to post data to external API");
//    }
//    return Results.Ok();
//});