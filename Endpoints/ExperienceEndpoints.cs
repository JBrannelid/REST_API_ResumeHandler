using Microsoft.EntityFrameworkCore;
using REST_API_ResumeHandler.Data;
using REST_API_ResumeHandler.DTOs.Experience;
using REST_API_ResumeHandler.Models;
using System.ComponentModel.DataAnnotations;

namespace REST_API_ResumeHandler.Endpoints
{
    public static class ExperienceEndpoints
    {
        public static RouteGroupBuilder MapExperienceEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (AppDbContext ctx) =>
            {
                var experienceList = await ctx.Experiences.Select(e => new ExperienceDto
                {
                    ExperienceId = e.ExperienceId,
                    Title = e.Title,
                    Company = e.Company,
                    Description = e.Description,
                    StartYear = e.StartYear,
                    EndYear = e.EndYear,
                    FKPersonId = e.FKPersonId
                }).ToListAsync();

                // Statuscode 200 Ok
                return Results.Ok(experienceList);
            });

            group.MapGet("/{id}", async (AppDbContext ctx, int id) =>
            {
                var experience = await ctx.Experiences.Select(e => new ExperienceDto
                {
                    ExperienceId = e.ExperienceId,
                    Title = e.Title,
                    Company = e.Company,
                    Description = e.Description,
                    StartYear = e.StartYear,
                    EndYear = e.EndYear,
                    FKPersonId = e.FKPersonId
                }).FirstOrDefaultAsync(e => e.ExperienceId == id);

                // If the experience is found, return a 200 OK status with the experience details
                if (experience is not null)
                    return Results.Ok(experience);

                // If no experience is found, return a 404 Not Found status with a custom message
                return Results.NotFound("Sorry, this experience record doesn't exist in the system");
            });

            group.MapGet("/person/{personId}", async (AppDbContext ctx, int personId) =>
            {
                var experienceList = await ctx.Experiences
                    .Where(e => e.FKPersonId == personId) // Filter experiences by the FKPersonId
                    .Select(e => new ExperienceDto
                    {
                        ExperienceId = e.ExperienceId,
                        Title = e.Title,
                        Company = e.Company,
                        Description = e.Description,
                        StartYear = e.StartYear,
                        EndYear = e.EndYear,
                        FKPersonId = e.FKPersonId
                    }).ToListAsync();

                // If experience records are found, return experienceList with a 200 OK status
                if (experienceList.Any())
                    return Results.Ok(experienceList);

                return Results.NotFound($"No experience records found for person with ID {personId}");
            });

            group.MapPost("/", async (AppDbContext ctx, ExperienceDto newExperience) =>
            {
                // Create a validation context for the new experience DTO and prepare a list to collect validation results
                var validationContext = new ValidationContext(newExperience);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newExperience, validationContext, validationResult, true);

                // If the validation fails, return a 400 Bad Request with the validation error messages
                if (!isValid)
                {
                    return Results.BadRequest(validationResult.Select(v => v.ErrorMessage));
                }

                // Check if person with provided FKPersonId exists
                var person = await ctx.Persons.FindAsync(newExperience.FKPersonId);
                if (person is null)
                {
                    return Results.BadRequest($"Person with ID {newExperience.FKPersonId} does not exist");
                }

                // If validation and person check pass
                var experience = new Experience
                {
                    Title = newExperience.Title,
                    Company = newExperience.Company,
                    Description = newExperience.Description,
                    StartYear = newExperience.StartYear,
                    EndYear = newExperience.EndYear,
                    FKPersonId = newExperience.FKPersonId
                };

                ctx.Experiences.Add(experience);
                await ctx.SaveChangesAsync();

                return Results.Created($"/api/experience/{experience.ExperienceId}", experience);
            });

            group.MapPut("/{id}", async (AppDbContext ctx, int id, ExperienceDto updatedExperience) =>
            {
                var experience = await ctx.Experiences.FirstOrDefaultAsync(e => e.ExperienceId == id);
                if (experience is null)
                    return Results.NotFound("Sorry, this experience record doesn't exist in the system");

                // Check if the referenced person exists
                if (experience.FKPersonId != updatedExperience.FKPersonId)
                {
                    var person = await ctx.Persons.FindAsync(updatedExperience.FKPersonId);
                    if (person is null)
                    {
                        // If person is not found, return a 400 Bad Request with a custom message
                        return Results.BadRequest($"Person with ID {updatedExperience.FKPersonId} does not exist");
                    }
                }

                // Update the existing experience
                experience.Title = updatedExperience.Title;
                experience.Company = updatedExperience.Company;
                experience.Description = updatedExperience.Description;
                experience.StartYear = updatedExperience.StartYear;
                experience.EndYear = updatedExperience.EndYear;
                experience.FKPersonId = updatedExperience.FKPersonId;

                await ctx.SaveChangesAsync();

                // Statuscode: 200 Ok
                return Results.Ok(experience);
            });

            group.MapDelete("/{id}", async (AppDbContext ctx, int id) =>
            {
                var experience = await ctx.Experiences.FindAsync(id);
                if (experience is null)
                    return Results.NotFound("Sorry, this experience record doesn't exist in the system");

                ctx.Experiences.Remove(experience);
                await ctx.SaveChangesAsync();

                // Statuscode: 204 No Content
                return Results.NoContent();
            });

            return group;
        }
    }
}