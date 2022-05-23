using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vacancies.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vacancies",
                columns: table => new
                {
                    IdVacancy = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NumCandidates = table.Column<int>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacancies", x => x.IdVacancy);
                });

            migrationBuilder.InsertData(
                table: "vacancies",
                columns: new[] { "IdVacancy", "Description", "InsertDate", "Job", "NumCandidates" },
                values: new object[] { 1, "Do you have an excellent understanding of software development across multiple languages? We’re looking for a junior and mid-level full stack developers on all levels with knowledge of C#, .Net, SQL Server and Queue based systems and some exposure to the cloud (Microsoft Azure) to work on a wide range of products that form part of our offering. You should be able to maintain, bug fix and enhance existing software whilst working in a fast-paced environment. You will be expected to work with a variety of team’s members to develop and improve online applications for multiple platforms.", new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), ".NET Developer", 0 });

            migrationBuilder.InsertData(
                table: "vacancies",
                columns: new[] { "IdVacancy", "Description", "InsertDate", "Job", "NumCandidates" },
                values: new object[] { 2, "We are a results-oriented team and technology lovers, our incredibly multicultural and friendly team has proven itself as a major player in the digital landscape..", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Digital Marketing Manager", 0 });

            migrationBuilder.InsertData(
                table: "vacancies",
                columns: new[] { "IdVacancy", "Description", "InsertDate", "Job", "NumCandidates" },
                values: new object[] { 3, "As business operations product owner you’re responsible for the seamless operations of specific programs on the platform. The key objective is to have a smooth end-to-end internal operation of the distribution partner’s insurance program, from policy creation to claims fulfillment. You will take care of the implementation of processes, analysis of the operations and alignment across the different departments. Seeing that you’re the key liason for the different stakeholders, you’ll have first-hand insights on improvement opportunities and work closely together thereon with the product owner and tech teams.", new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business Operations Product Owner", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vacancies");
        }
    }
}
