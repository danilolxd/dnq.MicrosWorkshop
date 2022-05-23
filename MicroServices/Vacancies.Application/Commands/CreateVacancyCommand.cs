using MediatR;

namespace Vacancies.Application.Commands
{
    public class CreateVacancyCommand : IRequest
    {
        public string Job { get; }
        public string Description { get; }

        public CreateVacancyCommand(string job, string description)
        {
            Job = job;
            Description = description;
        }
    }
}