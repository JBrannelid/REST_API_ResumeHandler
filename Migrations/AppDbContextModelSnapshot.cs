﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REST_API_ResumeHandler.Data;

#nullable disable

namespace REST_API_ResumeHandler.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("REST_API_ResumeHandler.Models.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EducationId"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<int>("FKPersonId")
                        .HasColumnType("int");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("EducationId");

                    b.HasIndex("FKPersonId");

                    b.ToTable("Educations");

                    b.HasData(
                        new
                        {
                            EducationId = 1,
                            Degree = "Sjuksköterskeexamen",
                            EndYear = 2019,
                            FKPersonId = 1,
                            School = "Karolinska Institutet",
                            StartYear = 2016
                        },
                        new
                        {
                            EducationId = 2,
                            Degree = "Specialistutbildning Akutsjukvård",
                            EndYear = 2021,
                            FKPersonId = 1,
                            School = "Röda Korsets Högskola",
                            StartYear = 2020
                        },
                        new
                        {
                            EducationId = 3,
                            Degree = "Kandidatexamen i Ekonomi",
                            EndYear = 2013,
                            FKPersonId = 2,
                            School = "Stockholms Universitet",
                            StartYear = 2010
                        },
                        new
                        {
                            EducationId = 4,
                            Degree = "Kurs i Offentlig Upphandling",
                            EndYear = 2014,
                            FKPersonId = 2,
                            School = "Stockholms Universitet",
                            StartYear = 2014
                        },
                        new
                        {
                            EducationId = 5,
                            Degree = "Bachelor of Design med inriktning UX/UI",
                            EndYear = 2015,
                            FKPersonId = 3,
                            School = "Malmö Högskola",
                            StartYear = 2012
                        },
                        new
                        {
                            EducationId = 6,
                            Degree = "Digital Experience Design",
                            EndYear = 2017,
                            FKPersonId = 3,
                            School = "Hyper Island",
                            StartYear = 2016
                        },
                        new
                        {
                            EducationId = 7,
                            Degree = "Master of Science in Software Engineering",
                            EndYear = 2013,
                            FKPersonId = 4,
                            School = "Linköpings Universitet",
                            StartYear = 2008
                        },
                        new
                        {
                            EducationId = 8,
                            Degree = "Certifiering i Agil Systemutveckling",
                            EndYear = 2015,
                            FKPersonId = 4,
                            School = "Dataföreningen",
                            StartYear = 2015
                        });
                });

            modelBuilder.Entity("REST_API_ResumeHandler.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperienceId"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<int>("FKPersonId")
                        .HasColumnType("int");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ExperienceId");

                    b.HasIndex("FKPersonId");

                    b.ToTable("Experiences");

                    b.HasData(
                        new
                        {
                            ExperienceId = 1,
                            Company = "Karolinska Universitetssjukhuset",
                            Description = "Arbete på akutmottagningen med mottagning av patienter och akuta insatser.",
                            FKPersonId = 1,
                            StartYear = 2021,
                            Title = "Sjuksköterska"
                        },
                        new
                        {
                            ExperienceId = 2,
                            Company = "Södersjukhuset",
                            Description = "Arbete på medicinmottagningen och vårdavdelning.",
                            EndYear = 2021,
                            FKPersonId = 1,
                            StartYear = 2019,
                            Title = "Sjuksköterska"
                        },
                        new
                        {
                            ExperienceId = 3,
                            Company = "Stockholms Kommun",
                            Description = "Ansvarig för upphandlingar inom IT och digitala tjänster.",
                            FKPersonId = 2,
                            StartYear = 2018,
                            Title = "Senior Upphandlare"
                        },
                        new
                        {
                            ExperienceId = 4,
                            Company = "Upphandlingsmyndigheten",
                            Description = "Arbete med offentliga upphandlingar och rådgivning till offentlig sektor.",
                            EndYear = 2018,
                            FKPersonId = 2,
                            StartYear = 2014,
                            Title = "Upphandlare"
                        },
                        new
                        {
                            ExperienceId = 5,
                            Company = "DesignWorks",
                            Description = "Ansvarig för användarupplevelse och gränssnitt på företagets digitala produkter.",
                            FKPersonId = 3,
                            StartYear = 2017,
                            Title = "Senior UX/UI Designer"
                        },
                        new
                        {
                            ExperienceId = 6,
                            Company = "Creative Studio",
                            Description = "Formgivning av visuella identiteter och marknadsföringsmaterial.",
                            EndYear = 2017,
                            FKPersonId = 3,
                            StartYear = 2015,
                            Title = "Grafisk Designer"
                        },
                        new
                        {
                            ExperienceId = 7,
                            Company = "Enterprise Systems",
                            Description = "Design av skalbara och underhållbara systemarkitekturer för stora företag.",
                            FKPersonId = 4,
                            StartYear = 2019,
                            Title = "Systemarkitekt"
                        },
                        new
                        {
                            ExperienceId = 8,
                            Company = "Backend Solutions",
                            Description = "Utveckling av högpresterande API:er och tjänster.",
                            EndYear = 2019,
                            FKPersonId = 4,
                            StartYear = 2013,
                            Title = "Senior Backendutvecklare"
                        });
                });

            modelBuilder.Entity("REST_API_ResumeHandler.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            Description = "Sjuksköterska inom akutsjukvården",
                            EmailAddress = "tolvan@email.com",
                            FirstName = "Tolvan",
                            LastName = "Tolvansson",
                            PhoneNumber = "0701234567"
                        },
                        new
                        {
                            PersonId = 2,
                            Description = "Upphandlare inom Stockholms Kommun",
                            EmailAddress = "elvan@email.com",
                            FirstName = "Elvan",
                            LastName = "Elvansson",
                            PhoneNumber = "0709876543"
                        },
                        new
                        {
                            PersonId = 3,
                            Description = "UX/UI designer med känsla för användarvänlighet.",
                            EmailAddress = "tian@email.com",
                            FirstName = "Tian",
                            LastName = "Tiansson",
                            PhoneNumber = "0706543210"
                        },
                        new
                        {
                            PersonId = 4,
                            Description = "Systemutvecklare med flera års arbetslivserfarenhet",
                            EmailAddress = "nian@email.com",
                            FirstName = "Nian",
                            LastName = "Niansson",
                            PhoneNumber = "0707654321"
                        });
                });

            modelBuilder.Entity("REST_API_ResumeHandler.Models.Education", b =>
                {
                    b.HasOne("REST_API_ResumeHandler.Models.Person", "Person")
                        .WithMany("Educations")
                        .HasForeignKey("FKPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("REST_API_ResumeHandler.Models.Experience", b =>
                {
                    b.HasOne("REST_API_ResumeHandler.Models.Person", "Person")
                        .WithMany("Experiences")
                        .HasForeignKey("FKPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("REST_API_ResumeHandler.Models.Person", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("Experiences");
                });
#pragma warning restore 612, 618
        }
    }
}
