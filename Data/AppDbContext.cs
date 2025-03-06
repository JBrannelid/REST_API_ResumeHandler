using Microsoft.EntityFrameworkCore;
using REST_API_ResumeHandler.Models.Internal;

namespace REST_API_ResumeHandler.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }


        // Seed the database with test data
        // This approach creates sample persons, their education history, and work experiences
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Persons
            modelBuilder.Entity<Person>().HasData(
                // Tolvan Tolvansson - Sjuksköterska
                new Person
                {
                    PersonId = 1,
                    FirstName = "Tolvan",
                    LastName = "Tolvansson",
                    EmailAddress = "tolvan@email.com",
                    PhoneNumber = "0701234567",
                    Description = "Sjuksköterska inom akutsjukvården"
                },
                // Elvan Elvansson - Upphandlare
                new Person
                {
                    PersonId = 2,
                    FirstName = "Elvan",
                    LastName = "Elvansson",
                    EmailAddress = "elvan@email.com",
                    PhoneNumber = "0709876543",
                    Description = "Upphandlare inom Stockholms Kommun"
                },
                // Tian Tiansson - UX/UI designer
                new Person
                {
                    PersonId = 3,
                    FirstName = "Tian",
                    LastName = "Tiansson",
                    EmailAddress = "tian@email.com",
                    PhoneNumber = "0706543210",
                    Description = "UX/UI designer med känsla för användarvänlighet."
                },
                // Nian Niansson - Systemutvecklare
                new Person
                {
                    PersonId = 4,
                    FirstName = "Nian",
                    LastName = "Niansson",
                    EmailAddress = "nian@email.com",
                    PhoneNumber = "0707654321",
                    Description = "Systemutvecklare med flera års arbetslivserfarenhet"
                }
            );

            // Seed Educations
            modelBuilder.Entity<Education>().HasData(
                // Tolvan's education - sjuksköterska
                new Education
                {
                    EducationId = 1,
                    School = "Karolinska Institutet",
                    Degree = "Sjuksköterskeexamen",
                    StartYear = 2016,
                    EndYear = 2019,
                    FKPersonId = 1
                },
                new Education
                {
                    EducationId = 2,
                    School = "Röda Korsets Högskola",
                    Degree = "Specialistutbildning Akutsjukvård",
                    StartYear = 2020,
                    EndYear = 2021,
                    FKPersonId = 1
                },

                // Elvan's education - upphandlare
                new Education
                {
                    EducationId = 3,
                    School = "Stockholms Universitet",
                    Degree = "Kandidatexamen i Ekonomi",
                    StartYear = 2010,
                    EndYear = 2013,
                    FKPersonId = 2
                },
                new Education
                {
                    EducationId = 4,
                    School = "Stockholms Universitet",
                    Degree = "Kurs i Offentlig Upphandling",
                    StartYear = 2014,
                    EndYear = 2014,
                    FKPersonId = 2
                },

                // Tian's education - UX/UI designer
                new Education
                {
                    EducationId = 5,
                    School = "Malmö Högskola",
                    Degree = "Bachelor of Design med inriktning UX/UI",
                    StartYear = 2012,
                    EndYear = 2015,
                    FKPersonId = 3
                },
                new Education
                {
                    EducationId = 6,
                    School = "Hyper Island",
                    Degree = "Digital Experience Design",
                    StartYear = 2016,
                    EndYear = 2017,
                    FKPersonId = 3
                },

                // Nian's education - systemutvecklare
                new Education
                {
                    EducationId = 7,
                    School = "Linköpings Universitet",
                    Degree = "Master of Science in Software Engineering",
                    StartYear = 2008,
                    EndYear = 2013,
                    FKPersonId = 4
                },
                new Education
                {
                    EducationId = 8,
                    School = "Dataföreningen",
                    Degree = "Certifiering i Agil Systemutveckling",
                    StartYear = 2015,
                    EndYear = 2015,
                    FKPersonId = 4
                }
            );

            // Seed Experiences
            modelBuilder.Entity<Experience>().HasData(
                // Tolvan's experiences - sjuksköterska
                new Experience
                {
                    ExperienceId = 1,
                    Title = "Sjuksköterska",
                    Company = "Karolinska Universitetssjukhuset",
                    Description = "Arbete på akutmottagningen med mottagning av patienter och akuta insatser.",
                    StartYear = 2021,
                    EndYear = null, // Nuvarande jobb
                    FKPersonId = 1
                },
                new Experience
                {
                    ExperienceId = 2,
                    Title = "Sjuksköterska",
                    Company = "Södersjukhuset",
                    Description = "Arbete på medicinmottagningen och vårdavdelning.",
                    StartYear = 2019,
                    EndYear = 2021,
                    FKPersonId = 1
                },

                // Elvan's experiences - upphandlare
                new Experience
                {
                    ExperienceId = 3,
                    Title = "Senior Upphandlare",
                    Company = "Stockholms Kommun",
                    Description = "Ansvarig för upphandlingar inom IT och digitala tjänster.",
                    StartYear = 2018,
                    EndYear = null, // Nuvarande jobb
                    FKPersonId = 2
                },
                new Experience
                {
                    ExperienceId = 4,
                    Title = "Upphandlare",
                    Company = "Upphandlingsmyndigheten",
                    Description = "Arbete med offentliga upphandlingar och rådgivning till offentlig sektor.",
                    StartYear = 2014,
                    EndYear = 2018,
                    FKPersonId = 2
                },

                // Tian's experiences - UX/UI designer
                new Experience
                {
                    ExperienceId = 5,
                    Title = "Senior UX/UI Designer",
                    Company = "DesignWorks",
                    Description = "Ansvarig för användarupplevelse och gränssnitt på företagets digitala produkter.",
                    StartYear = 2017,
                    EndYear = null, // Nuvarande jobb
                    FKPersonId = 3
                },
                new Experience
                {
                    ExperienceId = 6,
                    Title = "Grafisk Designer",
                    Company = "Creative Studio",
                    Description = "Formgivning av visuella identiteter och marknadsföringsmaterial.",
                    StartYear = 2015,
                    EndYear = 2017,
                    FKPersonId = 3
                },

                // Nian's experiences - systemutvecklare
                new Experience
                {
                    ExperienceId = 7,
                    Title = "Systemarkitekt",
                    Company = "Enterprise Systems",
                    Description = "Design av skalbara och underhållbara systemarkitekturer för stora företag.",
                    StartYear = 2019,
                    EndYear = null, // Nuvarande jobb
                    FKPersonId = 4
                },
                new Experience
                {
                    ExperienceId = 8,
                    Title = "Senior Backendutvecklare",
                    Company = "Backend Solutions",
                    Description = "Utveckling av högpresterande API:er och tjänster.",
                    StartYear = 2013,
                    EndYear = 2019,
                    FKPersonId = 4
                }
            );
        }
    }
}