namespace DataStorage
{
    public class DbConnectionStringConfig : IDbConnectionStringConfig
    {
        public string OrderManagmentDbConnectionString { get; set; }
        public string InventoryManagmentDbConnectionString { get; set; }
        public string CrmDbConnectionString { get; set; }
        public string HrDbConnectionString { get; set; }
    }
}