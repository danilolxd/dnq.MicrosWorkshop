using Common.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public abstract class ContextBase : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public ContextBase(DbContextOptions options) : base(options) { }

        public ContextBase(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
            await _mediator.DispatchDomainEventsAsync(this);
        }
    }
}
