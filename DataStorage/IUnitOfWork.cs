using System.Threading;
using System.Threading.Tasks;

namespace DataStorage
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync(CancellationToken token = default);
        void Rollback();
        Task RollbackAsync(CancellationToken token = default);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}