using Microsoft.EntityFrameworkCore;
using System;
using Vacancies.Domain.Entities;

namespace Vacancies.Infrastructure.Seeds
{
    internal class VacancySeed
    {
        public VacancySeed()
        {
        }

        internal void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacancy>().HasData(new[]{
                new { IdVacancy = 1, Job = ".NET Developer", InsertDate = new DateTime(2022, 1, 31), NumCandidates = 0, Description = "Do you have an excellent understanding of software development across multiple languages? We’re looking for a junior and mid-level full stack developers on all levels with knowledge of C#, .Net, SQL Server and Queue based systems and some exposure to the cloud (Microsoft Azure) to work on a wide range of products that form part of our offering. You should be able to maintain, bug fix and enhance existing software whilst working in a fast-paced environment. You will be expected to work with a variety of team’s members to develop and improve online applications for multiple platforms." },
                new { IdVacancy = 2, Job = "Digital Marketing Manager", InsertDate = new DateTime(2022, 3, 5), NumCandidates = 0, Description = "We are a results-oriented team and technology lovers, our incredibly multicultural and friendly team has proven itself as a major player in the digital landscape.." },
                new { IdVacancy = 3, Job = "Business Operations Product Owner", InsertDate = new DateTime(2022, 4, 22), NumCandidates = 0, Description = "As business operations product owner you’re responsible for the seamless operations of specific programs on the platform. The key objective is to have a smooth end-to-end internal operation of the distribution partner’s insurance program, from policy creation to claims fulfillment. You will take care of the implementation of processes, analysis of the operations and alignment across the different departments. Seeing that you’re the key liason for the different stakeholders, you’ll have first-hand insights on improvement opportunities and work closely together thereon with the product owner and tech teams." },
            });
        }
    }
}
