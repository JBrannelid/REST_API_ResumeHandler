using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace REST_API_ResumeHandler.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Description", "EmailAdress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Sjuksköterska inom akutsjukvården", "tolvan@email.com", "Tolvan", "Tolvansson", "0701234567" },
                    { 2, "Upphandlare inom Stockholms Kommun", "elvan@email.com", "Elvan", "Elvansson", "0709876543" },
                    { 3, "UX/UI designer med känsla för användarvänlighet.", "tian@email.com", "Tian", "Tiansson", "0706543210" },
                    { 4, "Systemutvecklare med flera års arbetslivserfarenhet", "nian@email.com", "Nian", "Niansson", "0707654321" }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "Degree", "EndYear", "FKPersonId", "School", "StartYear" },
                values: new object[,]
                {
                    { 1, "Sjuksköterskeexamen", 2019, 1, "Karolinska Institutet", 2016 },
                    { 2, "Specialistutbildning Akutsjukvård", 2021, 1, "Röda Korsets Högskola", 2020 },
                    { 3, "Kandidatexamen i Ekonomi", 2013, 2, "Stockholms Universitet", 2010 },
                    { 4, "Kurs i Offentlig Upphandling", 2014, 2, "Stockholms Universitet", 2014 },
                    { 5, "Bachelor of Design med inriktning UX/UI", 2015, 3, "Malmö Högskola", 2012 },
                    { 6, "Digital Experience Design", 2017, 3, "Hyper Island", 2016 },
                    { 7, "Master of Science in Software Engineering", 2013, 4, "Linköpings Universitet", 2008 },
                    { 8, "Certifiering i Agil Systemutveckling", 2015, 4, "Dataföreningen", 2015 }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "ExperienceId", "Company", "Description", "EndYear", "FKPersonId", "StartYear", "Title" },
                values: new object[,]
                {
                    { 1, "Karolinska Universitetssjukhuset", "Arbete på akutmottagningen med mottagning av patienter och akuta insatser.", null, 1, 2021, "Sjuksköterska" },
                    { 2, "Södersjukhuset", "Arbete på medicinmottagningen och vårdavdelning.", 2021, 1, 2019, "Sjuksköterska" },
                    { 3, "Stockholms Kommun", "Ansvarig för upphandlingar inom IT och digitala tjänster.", null, 2, 2018, "Senior Upphandlare" },
                    { 4, "Upphandlingsmyndigheten", "Arbete med offentliga upphandlingar och rådgivning till offentlig sektor.", 2018, 2, 2014, "Upphandlare" },
                    { 5, "DesignWorks", "Ansvarig för användarupplevelse och gränssnitt på företagets digitala produkter.", null, 3, 2017, "Senior UX/UI Designer" },
                    { 6, "Creative Studio", "Formgivning av visuella identiteter och marknadsföringsmaterial.", 2017, 3, 2015, "Grafisk Designer" },
                    { 7, "Enterprise Systems", "Design av skalbara och underhållbara systemarkitekturer för stora företag.", null, 4, 2019, "Systemarkitekt" },
                    { 8, "Backend Solutions", "Utveckling av högpresterande API:er och tjänster.", 2019, 4, 2013, "Senior Backendutvecklare" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "EducationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 4);
        }
    }
}
