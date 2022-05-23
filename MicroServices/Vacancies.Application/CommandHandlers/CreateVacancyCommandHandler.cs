using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vacancies.Application.Commands;
using Vacancies.Application.Repositories.Contracts;
using Vacancies.Domain.Entities;

namespace Vacancies.Application.CommandHandlers
{
    public class CreateVacancyCommandHandler : IRequestHandler<CreateVacancyCommand>
    {
        private readonly IVacancyRepository _vacancyRepository;

        public CreateVacancyCommandHandler(IVacancyRepository vacancyRepository)
        {
            _vacancyRepository = vacancyRepository ?? throw new ArgumentNullException(nameof(vacancyRepository));
        }

        public async Task<Unit> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            var vacancy = new Vacancy(request.Job, request.Description);

            await _vacancyRepository.AddAsync(vacancy);
            await _vacancyRepository.UnitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}