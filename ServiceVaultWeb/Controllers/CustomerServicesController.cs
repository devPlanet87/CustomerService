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

            model.CreatedBy = "Admin";
            model.CreatedDateTime = DateTime.Now;
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

            // Load existing entity to preserve any values not present in the form
            var existing = await _manager.GetByIdAsync(id);
            if (existing == null) return NotFound();

            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync();
                return View(model);
            }

            // Copy only editable fields from posted model. Preserve other fields as-is.
            existing.CustomerId = model.CustomerId;
            existing.MobileNumber = model.MobileNumber;
            existing.Location = model.Location;
            existing.ProductId = model.ProductId;
            existing.ProductsDetail = model.ProductsDetail;
            existing.Remarks = model.Remarks;

            // Update audit fields
            existing.UpdatedDateTime = DateTime.Now;
            existing.UpdatedBy = "Admin";

            await _manager.UpdateAsync(existing);
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateSelectListsAsync()
        {
            var products = await _manager.GetProductsAsync();
            var customers = await _manager.GetCustomersAsync();
            var productItems = products
                .Select(p => new SelectListItem(p.ProductName, p.ProductId.ToString()))
                .ToList();
            productItems.Insert(0, new SelectListItem { Value = "", Text = "-- Select Product --" });

            var customerItems = customers
                .Select(c => new SelectListItem(c.CustomerName, c.CustomerId.ToString()))
                .ToList();
            customerItems.Insert(0, new SelectListItem { Value = "", Text = "-- Select Customer --" });

            ViewBag.Products = productItems;
            ViewBag.Customers = customerItems;
        }
    }
}
