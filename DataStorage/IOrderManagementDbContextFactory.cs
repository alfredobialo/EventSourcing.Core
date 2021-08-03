using Microsoft.EntityFrameworkCore;

namespace DataStorage
{
    public interface IOrderManagementDbContextFactory
    {
        DbContext GetDefault();
    }
}