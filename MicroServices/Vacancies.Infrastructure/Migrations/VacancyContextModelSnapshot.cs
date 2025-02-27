﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vacancies.Infrastructure.Contexts;

namespace Vacancies.Infrastructure.Migrations
{
    [DbContext(typeof(VacancyContext))]
    partial class VacancyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vacancies.Domain.Entities.Vacancy", b =>
                {
                    b.Property<int>("IdVacancy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumCandidates")
                        .HasColumnType("int");

                    b.HasKey("IdVacancy");

                    b.ToTable("vacancies");

                    b.HasData(
                        new
                        {
                            IdVacancy = 1,
                            Description = "Do you have an excellent understanding of software development across multiple languages? We’re looking for a junior and mid-level full stack developers on all levels with knowledge of C#, .Net, SQL Server and Queue based systems and some exposure to the cloud (Microsoft Azure) to work on a wide range of products that form part of our offering. You should be able to maintain, bug fix and enhance existing software whilst working in a fast-paced environment. You will be expected to work with a variety of team’s members to develop and improve online applications for multiple platforms.",
                            InsertDate = new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Job = ".NET Developer",
                            NumCandidates = 0
                        },
                        new
                        {
                            IdVacancy = 2,
                            Description = "We are a results-oriented team and technology lovers, our incredibly multicultural and friendly team has proven itself as a major player in the digital landscape..",
                            InsertDate = new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Job = "Digital Marketing Manager",
                            NumCandidates = 0
                        },
                        new
                        {
                            IdVacancy = 3,
                            Description = "As business operations product owner you’re responsible for the seamless operations of specific programs on the platform. The key objective is to have a smooth end-to-end internal operation of the distribution partner’s insurance program, from policy creation to claims fulfillment. You will take care of the implementation of processes, analysis of the operations and alignment across the different departments. Seeing that you’re the key liason for the different stakeholders, you’ll have first-hand insights on improvement opportunities and work closely together thereon with the product owner and tech teams.",
                            InsertDate = new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Job = "Business Operations Product Owner",
                            NumCandidates = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
