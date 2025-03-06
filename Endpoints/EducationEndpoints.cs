using Microsoft.EntityFrameworkCore;
using REST_API_ResumeHandler.Data;
using REST_API_ResumeHandler.DTOs.Education;
using REST_API_ResumeHandler.Models;
using REST_API_ResumeHandler.Models.Internal;
using System.ComponentModel.DataAnnotations;

namespace REST_API_ResumeHandler.Endpoints
{
    public static class EducationEndpoints
    {
        public static RouteGroupBuilder MapEducationEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (AppDbContext ctx) =>
            {
                var educationList = await ctx.Educations.Select(e => new PublicEducationDto
                {
                    School = e.School,
                    Degree = e.Degree,
                    StartYear = e.StartYear,
                    EndYear = e.EndYear
                }).ToListAsync();

                // Statuscode: 200 ok
                return Results.Ok(educationList);
            });

            group.MapGet("/{id}", async (AppDbContext ctx, int id) =>
            {
                var education = await ctx.Educations
                .Where(e => e.EducationId == id)
                .Select(e => new PublicEducationDto
                {
                    School = e.School,
                    Degree = e.Degree,
                    StartYear = e.StartYear,
                    EndYear = e.EndYear
                }).FirstOrDefaultAsync();

                if (education is not null)
                    // Statuscode: 200 ok
                    return Results.Ok(education);

                // Statuscode: 404 Not Found
                return Results.NotFound("Sorry, this education record doesn't exist in the system");
            });

            group.MapGet("/person/{personId}", async (AppDbContext ctx, int personId) =>
            {
                var educationList = await ctx.Educations
                    .Where(e => e.FKPersonId == personId)
                    .Select(e => new PublicEducationDto
                    {
                        School = e.School,
                        Degree = e.Degree,
                        StartYear = e.StartYear,
                        EndYear = e.EndYear
                    }).ToListAsync();

                if (educationList.Any())
                    // Statuscode: 200 ok
                    return Results.Ok(educationList);

                // Statuscode: 404 Not Found
                return Results.NotFound($"No education records found for person with ID {personId}");
            });

            group.MapPost("/", async (AppDbContext ctx, CreateEducationDto newEducation) =>
            {
                // Create a validation context for the new experience DTO and prepare a list to collect validation results
                var validationContext = new ValidationContext(newEducation);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newEducation, validationContext, validationResult, true);

                if (!isValid)
                {
                    // Statuscode: 400 Bad Request
                    return Results.BadRequest(validationResult.Select(v => v.ErrorMessage));
                }

                // Check if person with provided FKPersonId exists
                var person = await ctx.Persons.FindAsync(newEducation.FKPersonId);
                if (person is null)
                {
                    // Statuscode: 400 Bad Request
                    return Results.BadRequest($"Person with ID {newEducation.FKPersonId} does not exist");
                }

                // If validation and person check pass
                var education = new Education
                {
                    School = newEducation.School,
                    Degree = newEducation.Degree,
                    StartYear = newEducation.StartYear,
                    EndYear = newEducation.EndYear,
                    FKPersonId = newEducation.FKPersonId
                };

                ctx.Educations.Add(education);
                await ctx.SaveChangesAsync();

                // Return response DTO
                var responseDto = new PublicEducationDto
                {
                    School = education.School,
                    Degree = education.Degree,
                    StartYear = education.StartYear,
                    EndYear = education.EndYear
                };

                // Statuscode: 201 Created
                return Results.Created($"/api/education/{education.EducationId}", responseDto);
            });

            group.MapPut("/{id}", async (AppDbContext ctx, int id, UpdateEducationDto updatedEducation) =>
            {
                var education = await ctx.Educations.FirstOrDefaultAsync(e => e.EducationId == id);
                if (education is null)
                    // Statuscode: 404 Not Found
                    return Results.NotFound("Sorry, this education record doesn't exist in the system");

                // Check if the referenced person exists when FKPersonId changes
                if (education.FKPersonId != updatedEducation.FKPersonId)
                {
                    var person = await ctx.Persons.FindAsync(updatedEducation.FKPersonId);

                    if (person is null)
                    {
                        // Statuscode: 400 Bad Request
                        return Results.BadRequest($"Person with ID {updatedEducation.FKPersonId} does not exist");
                    }
                }

                // Update the existing education
                education.School = updatedEducation.School;
                education.Degree = updatedEducation.Degree;
                education.StartYear = updatedEducation.StartYear;
                education.EndYear = updatedEducation.EndYear;
                education.FKPersonId = updatedEducation.FKPersonId;

                await ctx.SaveChangesAsync();

                // Return response DTO
                var responseDto = new EducationResponseDto
                {
                    EducationId = education.EducationId,
                    School = education.School,
                    Degree = education.Degree,
                    StartYear = education.StartYear,
                    EndYear = education.EndYear,
                    FKPersonId = education.FKPersonId
                };

                return Results.Ok(responseDto);
            });

            group.MapDelete("/{id}", async (AppDbContext ctx, int id) =>
            {
                var education = await ctx.Educations.FindAsync(id);

                if (education is null)
                    // Statuscode: 404 Not Found
                    return Results.NotFound("Sorry, this education record doesn't exist in the system");

                ctx.Educations.Remove(education);
                await ctx.SaveChangesAsync();

                // Statuscode: 204 No Content
                return Results.NoContent();
            });

            return group;
        }
    }
}