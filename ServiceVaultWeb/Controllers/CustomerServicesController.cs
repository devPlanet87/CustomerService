using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceVaultWeb.Models;
using ServiceVaultWeb.Services;

namespace ServiceVaultWeb.Controllers
{
    /// <summary>
    /// MVC controller for managing customer services.
    /// </summary>
    public class CustomerServicesController : Controller
    {
        private readonly ICustomerServiceManager _manager;

        public CustomerServicesController(ICustomerServiceManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Shows the list of customer services.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var list = await _manager.GetAllAsync();
            return View(list);
        }

        /// <summary>
        /// Renders create form.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            await PopulateSelectListsAsync();
            return View();
        }

        /// <summary>
        /// Handles create post.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerService model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync();
                return View(model);
            }

            await _manager.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Renders edit form.
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _manager.GetByIdAsync(id);
            if (entity == null) return NotFound();
            await PopulateSelectListsAsync();
            return View(entity);
        }

        /// <summary>
        /// Handles edit post.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerService model)
        {
            if (id != model.CustomerServiceId) return BadRequest();
            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync();
                return View(model);
            }

            await _manager.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateSelectListsAsync()
        {
            var products = await _manager.GetProductsAsync();
            var customers = await _manager.GetCustomersAsync();
            ViewBag.Products = new SelectList(products, "ProductId", "ProductName");
            ViewBag.Customers = new SelectList(customers, "CustomerId", "CustomerName");
        }
    }
}
