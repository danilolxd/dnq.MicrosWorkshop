using Common.Application;
using Common.Domain;
using System;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public abstract class EFRepository<T, Y> : IRepository<T, Y> where T : class
    {
        protected readonly ContextBase _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public EFRepository(ContextBase dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(T entity) =>
            await _dbContext.Set<T>().AddAsync(entity);

        public virtual async Task<T> GetByIdAsync(Y id) =>
            await _dbContext.Set<T>().FindAsync(id);
    }
}
