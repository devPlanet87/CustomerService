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
        // CustomerInfo CRUD
        Task<List<CustomerInfo>> GetCustomersAsync();
        Task<CustomerInfo?> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerInfo entity);
        Task UpdateCustomerAsync(CustomerInfo entity);
        Task<List<Product>> GetProductsAsync();
    }
}
