using ServiceVaultWeb.Models;

namespace ServiceVaultWeb.Repositories
{
    /// <summary>
    /// Repository contract for customer service data access.
    /// </summary>
    public interface ICustomerServiceRepository
    {
        Task<List<CustomerService>> GetAllAsync();
        Task<CustomerService?> GetByIdAsync(int id);
        Task AddAsync(CustomerService entity);
        Task UpdateAsync(CustomerService entity);
        Task<List<Product>> GetProductsAsync();
        Task<List<CustomerInfo>> GetCustomersAsync();
    }
}
