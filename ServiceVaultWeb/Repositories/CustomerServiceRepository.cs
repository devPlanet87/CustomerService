using Microsoft.EntityFrameworkCore;
using ServiceVaultWeb.Data;
using ServiceVaultWeb.Models;

namespace ServiceVaultWeb.Repositories
{
    /// <summary>
    /// EF Core implementation of ICustomerServiceRepository.
    /// </summary>
    public class CustomerServiceRepository : ICustomerServiceRepository
    {
        private readonly ServiceVaultContext _context;

        public CustomerServiceRepository(ServiceVaultContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CustomerService entity)
        {
            entity.CreatedBy = "Admin";
            entity.CreatedDateTime = DateTime.Now;
            await _context.CustomerServices.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomerService>> GetAllAsync()
        {
            return await _context.CustomerServices
                .Include(x => x.Product)
                .Include(x => x.Customer)
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedDateTime)
                .ToListAsync();
        }

        public async Task<CustomerService?> GetByIdAsync(int id)
        {
            return await _context.CustomerServices
                .Include(x => x.Product)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.CustomerServiceId == id);
        }

        public async Task UpdateAsync(CustomerService entity)
        {
            _context.CustomerServices.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.AsNoTracking().Where(p => p.ProductId > 0).ToListAsync();
        }

        public async Task<List<CustomerInfo>> GetCustomersAsync()
        {
            return await _context.CustomerInfo.AsNoTracking().Where(c => c.CustomerId > 0).ToListAsync();
        }
    }
}
