using ServiceVaultWeb.Models;

namespace ServiceVaultWeb.Services
{
    /// <summary>
    /// Business service contract for customer service operations.
    /// </summary>
    public interface ICustomerServiceManager
    {
        Task<List<CustomerService>> GetAllAsync();
        Task<CustomerService?> GetByIdAsync(int id);
        Task AddAsync(CustomerService entity);
        Task UpdateAsync(CustomerService entity);
        Task<List<Product>> GetProductsAsync();
        Task<List<CustomerInfo>> GetCustomersAsync();
    }
}
