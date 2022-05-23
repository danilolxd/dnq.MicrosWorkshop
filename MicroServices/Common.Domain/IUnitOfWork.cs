using System;
using System.Threading.Tasks;

namespace Common.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
    }
}