
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

            // Register DbContext in DI-container 
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Call Endpoints by Rout group builder
            app.MapGroup("/api/person").MapPersonEndpoints();
            app.MapGroup("/api/education").MapEducationEndpoints();
            app.MapGroup("/api/experience").MapExperienceEndpoints();

            app.Run();
        }
    }
}

/*  Reference
 *  Youtube: https://www.youtube.com/watch?v=VNmFvk49rJk
 */