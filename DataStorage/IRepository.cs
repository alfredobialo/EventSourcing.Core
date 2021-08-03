using System;
using System.Threading.Tasks;

namespace DataStorage
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddData(T entity);
        Task<bool> CreateNew(T entity);
        Task<bool> UpdateData(object key, Func<T> data);
    }

    public class SalesOrderTableRepository : IRepository<SalesOrderTable>
    {
        private readonly OrderManagementDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public SalesOrderTableRepository(IOrderManagementDbContextFactory dbContextFactory, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContextFactory.GetDefault() as OrderManagementDbContext;
            _unitOfWork = unitOfWork;
        }
        public async Task AddData(SalesOrderTable entity)
        {
            //TODO :Check for Exception and Validate Entries on The Repository Layer For Data consistency

            _dbContext.SalesOrders.Add(entity);
            bool success = await _unitOfWork.SaveChangesAsync() > 0;  // This could be Wrong

        }

        public async Task<bool> CreateNew(SalesOrderTable entity)
        {
            _dbContext.SalesOrders.Add(entity);
            bool success = await _unitOfWork.SaveChangesAsync() > 0;
            return success;
        }

        public Task<bool> UpdateData(object key, Func<SalesOrderTable> data)
        {
            // create a Patched Update based on fields that where set
            return null;
        }
    }
}
