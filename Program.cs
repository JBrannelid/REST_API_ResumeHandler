using Microsoft.EntityFrameworkCore;
using REST_API_ResumeHandler.Data;
using REST_API_ResumeHandler.Endpoints;

namespace REST_API_ResumeHandler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register SQL Server database context with connection string from configuration
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // HttpClient services for external API
            builder.Services.AddHttpClient();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Call internal endpoints using Route Group Builder organization of related endpoints
            // This approach groups endpoints by common path prefixes
            app.MapGroup("/api/person").MapPersonEndpoints();
            app.MapGroup("/api/education").MapEducationEndpoints();
            app.MapGroup("/api/experience").MapExperienceEndpoints();

            // Call external endpoints directly with direct mapping
            // Direct mapping for GitHub as it only has a single endpoint
            app.MapGitHubEndpoints();

            app.Run();
        }
    }
}

/*  Reference
 *  Youtube: https://www.youtube.com/watch?v=VNmFvk49rJk
 *  Repository: https://github.com/aldorQlok/CodeFirstDB.git
 */