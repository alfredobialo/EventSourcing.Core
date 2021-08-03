using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace DataStorage
{
    public class OrderManagementDbContext : DbContext
    {
        public OrderManagementDbContext(DbContextOptions opts) : base(opts)
        {

        }

        public DbSet<SalesOrderTable> SalesOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrderTable>(
                opt =>
                {
                    opt.HasKey(x => x.Id);
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
