using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DataStorage
{
    public class OrderManagementDbContextFactory : IOrderManagementDbContextFactory
    {
        private readonly IDbConnectionStringConfig _dbConnectionStringConfig;

        public OrderManagementDbContextFactory(IDbConnectionStringConfig dbConnectionStringConfig)
        {
            _dbConnectionStringConfig = dbConnectionStringConfig;
        }
        public DbContext GetDefault()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(_dbConnectionStringConfig.OrderManagmentDbConnectionString,
                opts =>
                {
                    opts.CommandTimeout(40);
                    opts.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
            return new OrderManagementDbContext(optionsBuilder.Options);
        }
    }
}