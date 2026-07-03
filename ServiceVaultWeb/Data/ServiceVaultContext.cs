using Microsoft.EntityFrameworkCore;
using ServiceVaultWeb.Models;

namespace ServiceVaultWeb.Data
{
    /// <summary>
    /// EF Core DB context for ServiceVault database.
    /// </summary>
    public class ServiceVaultContext : DbContext
    {
        public ServiceVaultContext(DbContextOptions<ServiceVaultContext> options) : base(options)
        {
        }

        public DbSet<CustomerService> CustomerServices { get; set; } = null!;
        public DbSet<CustomerInfo> CustomerInfo { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerService>().ToTable("CustomerServices");
            modelBuilder.Entity<CustomerInfo>().ToTable("CustomerInfo");
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
