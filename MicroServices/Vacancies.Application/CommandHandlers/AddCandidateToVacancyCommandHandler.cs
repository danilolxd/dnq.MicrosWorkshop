using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vacancies.Application.Commands;
using Vacancies.Application.Repositories.Contracts;

namespace Vacancies.Application.CommandHandlers
{
    public class AddCandidateToVacancyCommandHandler : IRequestHandler<AddCandidateToVacancyCommand>
    {
        private readonly IVacancyRepository _vacancyRepository;

        public AddCandidateToVacancyCommandHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository ?? throw new ArgumentNullException(nameof(vacancyRepository));
        }

        public async Task<Unit> Handle(AddCandidateToVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = await _vacancyRepository.GetByIdAsync(request.IdVacancy);

            vacancy.AddCandidate();

            await _vacancyRepository.UnitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}