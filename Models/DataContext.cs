using Microsoft.EntityFrameworkCore;
 
namespace MvcCustomerManager.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
    }
}