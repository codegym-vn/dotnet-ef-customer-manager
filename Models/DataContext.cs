using Microsoft.EntityFrameworkCore;

namespace MvcCustomerManager.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne<Province>(s => s.Province)
                .WithMany(p => p.Customers)
                .HasForeignKey(c => c.ProvinceId);
        }*/
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}