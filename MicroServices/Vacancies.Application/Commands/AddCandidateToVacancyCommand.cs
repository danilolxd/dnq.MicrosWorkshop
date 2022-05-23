using MediatR;

namespace Vacancies.Application.Commands
{
    public class AddCandidateToVacancyCommand : IRequest
    {
        public int IdVacancy { get; }

        public AddCandidateToVacancyCommand(int idVacancy)
        {
            IdVacancy = idVacancy;
        }
    }
}