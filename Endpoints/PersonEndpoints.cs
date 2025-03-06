using Microsoft.EntityFrameworkCore;
using REST_API_ResumeHandler.Data;
using REST_API_ResumeHandler.DTOs.Education;
using REST_API_ResumeHandler.DTOs.Experience;
using REST_API_ResumeHandler.DTOs.Person;
using REST_API_ResumeHandler.Models;
using REST_API_ResumeHandler.Models.Internal;
using System.ComponentModel.DataAnnotations;

namespace REST_API_ResumeHandler.Endpoints
{
    public static class PersonEndpoints
    {
        public static RouteGroupBuilder MapPersonEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (AppDbContext ctx) =>
            {
                // Map persons to response DTOs
                var personList = await ctx.Persons.Select(p => new PersonPublicDto
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    EmailAddress = p.EmailAddress,
                    PhoneNumber = p.PhoneNumber
                }).ToListAsync();

                return Results.Ok(personList);
            });

            group.MapGet("/{id}", async (AppDbContext ctx, int id) =>
            {
                var person = await ctx.Persons
                    .Where(p => p.PersonId == id)
                    .Select(p => new PersonPublicDto
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        EmailAddress = p.EmailAddress,
                        PhoneNumber = p.PhoneNumber
                    })
                    .FirstOrDefaultAsync();

                // Statuscode: 200 if updatedPerson is found - Else 404 Not Found
                if (person is not null)
                    return Results.Ok(person);

                return Results.NotFound("Sorry, this person dosn't exist in the system");
            });

            // Join person information with education and experience
            group.MapGet("/{id}/detail", async (AppDbContext ctx, int id) =>
            {
                var person = await ctx.Persons
                    .Where(p => p.PersonId == id)
                    .Include(p => p.Educations)
                    .Include(p => p.Experiences)
                    .FirstOrDefaultAsync();

                if (person is null)
                    return Results.NotFound("Sorry, this person doesn't exist in the system");

                // Map to detail response DTO
                var personDetail = new PersonDetailResponseDto
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    EmailAddress = person.EmailAddress,
                    PhoneNumber = person.PhoneNumber,
                    Description = person.Description,
                    Educations = person.Educations.Select(e => new PublicEducationDto
                    {
                        School = e.School,
                        Degree = e.Degree,
                        StartYear = e.StartYear,
                        EndYear = e.EndYear
                    }).ToList(),
                    Experiences = person.Experiences.Select(e => new PublicExperienceDto
                    {
                        Title = e.Title,
                        Company = e.Company,
                        Description = e.Description,
                        StartYear = e.StartYear,
                        EndYear = e.EndYear
                    }).ToList()
                };

                // Statuscode 200
                return Results.Ok(personDetail);
            });

            group.MapPost("/", async (AppDbContext ctx, CreatePersonDto newPerson) =>
            {
                // Create a validation context for the new experience DTO and prepare a list to collect validation results
                var validationContext = new ValidationContext(newPerson);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newPerson, validationContext, validationResult, true);

                // Check if person with provided FKPersonId exists
                if (!isValid)
                {
                    // Statuscode - 400 Bad request
                    return Results.BadRequest(validationResult.Select(v => v.ErrorMessage));
                }

                // If validation and person check pass - Map DTO to model and add to database
                var person = new Person
                {
                    FirstName = newPerson.FirstName,
                    LastName = newPerson.LastName,
                    EmailAddress = newPerson.EmailAddress,
                    PhoneNumber = newPerson.PhoneNumber,
                    Description = newPerson.Description
                };

                ctx.Persons.Add(person);
                await ctx.SaveChangesAsync();

                // Return response DTO
                var responseDto = new PersonResponseDto
                {
                    PersonId = person.PersonId,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    EmailAddress = person.EmailAddress,
                    PhoneNumber = person.PhoneNumber,
                    Description = person.Description
                };

                // Statuscode: 201 Created. Generate a header for accessing the new resource
                return Results.Created($"/api/person/{person.PersonId}", responseDto);
            });

            group.MapPut("/{id}", async (AppDbContext ctx, int id, UpdatePersonDto updatedPerson) =>
            {
                var person = await ctx.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
                if (person is null)
                    // Statuscode: 404 Not Found
                    return Results.NotFound("Sorry, this person doesn't exist in the system");

                // Update the existing updatedPerson model
                person.FirstName = updatedPerson.FirstName;
                person.LastName = updatedPerson.LastName;
                person.EmailAddress = updatedPerson.EmailAddress;
                person.PhoneNumber = updatedPerson.PhoneNumber;
                person.Description = updatedPerson.Description;

                await ctx.SaveChangesAsync();

                // Return response DTO
                var responseDto = new PersonResponseDto
                {
                    PersonId = person.PersonId,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    EmailAddress = person.EmailAddress,
                    PhoneNumber = person.PhoneNumber,
                    Description = person.Description
                };

                // Statuscode: 200 Ok
                return Results.Ok(responseDto);
            });

            group.MapDelete("/{id}", async (AppDbContext ctx, int id) =>
            {
                var person = await ctx.Persons.FindAsync(id);
                if (person is null)
                    // Statuscode 404 Not Found
                    return Results.NotFound("Sorry, this person doesn't exist in the system");

                ctx.Persons.Remove(person);
                await ctx.SaveChangesAsync();

                // Statuscode: 204 No Content
                return Results.NoContent();
            });

            return group;
        }
    }
}