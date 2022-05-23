using Common.Domain;
using System.Threading.Tasks;

namespace Common.Application
{
    public interface IRepository<T, Y> where T : class
    {
        IUnitOfWork UnitOfWork { get; }
        Task AddAsync(T entity);
        Task<T> GetByIdAsync(Y id);
    }
}