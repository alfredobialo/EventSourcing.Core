using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataStorage
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(IOrderManagementDbContextFactory orderManagementDbContextFactory )
        {
            _context = orderManagementDbContextFactory.GetDefault();
        }
        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public Task CommitAsync(CancellationToken token = default)
        {
            return _context.Database.CommitTransactionAsync(token);
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public Task RollbackAsync(CancellationToken token = default)
        {
            return _context.Database.RollbackTransactionAsync(token);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}