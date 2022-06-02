using Candidates.Application.Commands;
using Candidates.Application.Repositories.Contracts;
using Candidates.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Candidates.Application.CommandHandlers
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand>
    {
        private readonly ICandidateRepository _candidateRepository;

        public CreateCandidateCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository ?? throw new ArgumentNullException(nameof(candidateRepository));
        }

        public async Task<Unit> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = new Candidate(request.IdVacancy, request.Name, request.Surname, request.Email);

            await _candidateRepository.AddAsync(candidate);
            await _candidateRepository.UnitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}