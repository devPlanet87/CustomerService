using ServiceVaultWeb.Models;
using ServiceVaultWeb.Repositories;

namespace ServiceVaultWeb.Services
{
    /// <summary>
    /// Business service implementation for customer services.
    /// </summary>
    public class CustomerServiceManager : ICustomerServiceManager
    {
        private readonly ICustomerServiceRepository _repository;

        public CustomerServiceManager(ICustomerServiceRepository repository)
        {
            _repository = repository;
        }

        public Task AddAsync(CustomerService entity)
        {
            return _repository.AddAsync(entity);
        }

        public Task<List<CustomerService>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<CustomerService?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task UpdateAsync(CustomerService entity)
        {
            return _repository.UpdateAsync(entity);
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return _repository.GetProductsAsync();
        }

        public Task<List<CustomerInfo>> GetCustomersAsync()
        {
            return _repository.GetCustomersAsync();
        }
    }
}
