using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ServiceVaultWeb.Models;
using ServiceVaultWeb.Services;
using System.IO;

namespace ServiceVaultWeb.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerServiceManager _manager;
        private readonly IWebHostEnvironment _env;

        public CustomersController(ICustomerServiceManager manager, IWebHostEnvironment env)
        {
            _manager = manager;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _manager.GetCustomersAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerInfo model, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsRoot = Path.Combine(_env.WebRootPath ?? string.Empty, "ProductOrWarrantyImages");
                if (!Directory.Exists(uploadsRoot)) Directory.CreateDirectory(uploadsRoot);
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploadsRoot, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                model.ImagePath = fileName;
            }

            model.CreatedBy = "Admin";
            model.CreatedDateTime = DateTime.Now;
            await _manager.AddCustomerAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _manager.GetCustomerByIdAsync(id);
            if (entity == null) return NotFound();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerInfo model, IFormFile imageFile)
        {
            if (id != model.CustomerId) return BadRequest();

            var existing = await _manager.GetCustomerByIdAsync(id);
            if (existing == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsRoot = Path.Combine(_env.WebRootPath ?? string.Empty, "ProductOrWarrantyImages");
                if (!Directory.Exists(uploadsRoot)) Directory.CreateDirectory(uploadsRoot);
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                var filePath = Path.Combine(uploadsRoot, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                if (!string.IsNullOrEmpty(existing.ImagePath))
                {
                    var oldPath = Path.Combine(uploadsRoot, existing.ImagePath);
                    if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                }

                existing.ImagePath = fileName;
            }

            // copy editable fields
            existing.CustomerName = model.CustomerName;
            existing.NickName = model.NickName;
            existing.MobileNumber = model.MobileNumber;
            existing.AlternateNumber = model.AlternateNumber;
            existing.Address = model.Address;
            existing.Relationship = model.Relationship;
            existing.Notes = model.Notes;
            existing.MapLocation = model.MapLocation;

            existing.UpdatedBy = "Admin";
            existing.UpdatedDateTime = DateTime.Now;

            await _manager.UpdateCustomerAsync(existing);
            return RedirectToAction(nameof(Index));
        }
    }
}
