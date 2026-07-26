using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ServiceVaultWeb.Models;
using ServiceVaultWeb.Services;
using System.IO;

namespace ServiceVaultWeb.Controllers
{
    /// <summary>
    /// MVC controller for managing customer services.
    /// </summary>
    public class CustomerServicesController : Controller
    {
        private readonly ICustomerServiceManager _manager;
        private readonly IWebHostEnvironment _env;

        public CustomerServicesController(ICustomerServiceManager manager, IWebHostEnvironment env)
        {
            _manager = manager;
            _env = env;
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
        public async Task<IActionResult> Create(CustomerService model, IFormFile productOrWarrantyImage)
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync();
                return View(model);
            }
            // Handle image upload: store physical file and save only filename in DB
            if (productOrWarrantyImage != null && productOrWarrantyImage.Length > 0)
            {
                var uploadsRoot = Path.Combine(_env.WebRootPath ?? string.Empty, "ProductOrWarrantyImages");
                if (!Directory.Exists(uploadsRoot)) Directory.CreateDirectory(uploadsRoot);
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(productOrWarrantyImage.FileName)}";
                var filePath = Path.Combine(uploadsRoot, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await productOrWarrantyImage.CopyToAsync(stream);
                }

                model.ProductOrWarrantyImage = fileName;
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
        public async Task<IActionResult> Edit(int id, CustomerService model, IFormFile productOrWarrantyImage)
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
            // Handle image upload: if a new file was posted, save it and delete previous file
            if (productOrWarrantyImage != null && productOrWarrantyImage.Length > 0)
            {
                var uploadsRoot = Path.Combine(_env.WebRootPath ?? string.Empty, "ProductOrWarrantyImages");
                if (!Directory.Exists(uploadsRoot)) Directory.CreateDirectory(uploadsRoot);
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(productOrWarrantyImage.FileName)}";
                var filePath = Path.Combine(uploadsRoot, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await productOrWarrantyImage.CopyToAsync(stream);
                }

                // delete old file if present
                if (!string.IsNullOrEmpty(existing.ProductOrWarrantyImage))
                {
                    var oldPath = Path.Combine(uploadsRoot, existing.ProductOrWarrantyImage);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                existing.ProductOrWarrantyImage = fileName;
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
