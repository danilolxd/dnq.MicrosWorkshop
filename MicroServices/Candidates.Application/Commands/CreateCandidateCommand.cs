using MediatR;

namespace Candidates.Application.Commands
{
    public class CreateCandidateCommand : IRequest
    {

        public int IdVacancy { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }

        public CreateCandidateCommand(int idVacancy, string name, string surname, string email)
        {
            IdVacancy = idVacancy;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}