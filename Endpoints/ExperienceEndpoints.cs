using Microsoft.EntityFrameworkCore;
using REST_API_ResumeHandler.Data;
using REST_API_ResumeHandler.DTOs.Experience;
using REST_API_ResumeHandler.Models;
using REST_API_ResumeHandler.Models.Internal;
using System.ComponentModel.DataAnnotations;

namespace REST_API_ResumeHandler.Endpoints
{
    public static class ExperienceEndpoints
    {
        public static RouteGroupBuilder MapExperienceEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (AppDbContext ctx) =>
            {
                var experienceList = await ctx.Experiences.Select(e => new PublicExperienceDto
                {
                    Title = e.Title,
                    Company = e.Company,
                    Description = e.Description,
                    StartYear = e.StartYear,
                    EndYear = e.EndYear
                }).ToListAsync();

                // Statuscode 200 Ok
                return Results.Ok(experienceList);
            });

            group.MapGet("/{id}", async (AppDbContext ctx, int id) =>
            {
                var experience = await ctx.Experiences
                .Where(e => e.ExperienceId == id)
                .Select(e => new PublicExperienceDto
                {
                    Title = e.Title,
                    Company = e.Company,
                    Description = e.Description,
                    StartYear = e.StartYear,
                    EndYear = e.EndYear
                }).FirstOrDefaultAsync();

                // If the experience is found, return a 200 OK status with the experience details
                if (experience is not null)
                    // Statuscode 200 Ok
                    return Results.Ok(experience);

                // If no experience is found, return a 404 Not Found status with a custom message
                return Results.NotFound("Sorry, this experience record doesn't exist in the system");
            });

            group.MapGet("/person/{personId}", async (AppDbContext ctx, int personId) =>
            {
                var experienceList = await ctx.Experiences
                    .Where(e => e.FKPersonId == personId) // Filter experiences by the FKPersonId
                    .Select(e => new PublicExperienceDto
                    {
                        Title = e.Title,
                        Company = e.Company,
                        Description = e.Description,
                        StartYear = e.StartYear,
                        EndYear = e.EndYear
                    }).ToListAsync();

                // If experience records are found, return experienceList with a 200 OK status
                if (experienceList.Any())
                    // Statuscode 200 Ok
                    return Results.Ok(experienceList);

                // If no experience records are found, return a 404 Not Found status with a custom message
                return Results.NotFound($"No experience records found for person with ID {personId}");
            });

            group.MapPost("/", async (AppDbContext ctx, CreateExperienceDto newExperience) =>
            {
                // Create a validation context for the new experience DTO and prepare a list to collect validation results
                var validationContext = new ValidationContext(newExperience);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newExperience, validationContext, validationResult, true);

                // If the validation fails, return a 400 Bad Request with the validation error messages
                if (!isValid)
                {
                    // Statuscode: 400 Bad Request
                    return Results.BadRequest(validationResult.Select(v => v.ErrorMessage));
                }

                // Check if person with provided FKPersonId exists
                var person = await ctx.Persons.FindAsync(newExperience.FKPersonId);
                if (person is null)
                {
                    // Statuscode: 400 Bad Request
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

                // Return response DTO
                var responseDto = new PublicExperienceDto
                {
                    Title = experience.Title,
                    Company = experience.Company,
                    Description = experience.Description,
                    StartYear = experience.StartYear,
                    EndYear = experience.EndYear
                };

                return Results.Created($"/api/experience/{experience.ExperienceId}", responseDto);
            });

            group.MapPut("/{id}", async (AppDbContext ctx, int id, UpdateExperienceDto updatedExperience) =>
            {
                var experience = await ctx.Experiences.FirstOrDefaultAsync(e => e.ExperienceId == id);
                if (experience is null)
                    // Statuscode: 404 Not Found
                    return Results.NotFound("Sorry, this experience record doesn't exist in the system");

                // Check if the referenced person exists when FKPersonId changes
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

                // Return response DTO
                var responseDto = new ExperienceResponseDto
                {
                    ExperienceId = experience.ExperienceId,
                    Title = experience.Title,
                    Company = experience.Company,
                    Description = experience.Description,
                    StartYear = experience.StartYear,
                    EndYear = experience.EndYear,
                    FKPersonId = experience.FKPersonId
                };

                // Statuscode: 200 Ok
                return Results.Ok(responseDto);
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