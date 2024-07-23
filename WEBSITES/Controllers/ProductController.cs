using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WEBSITES.Data;
using WEBSITES.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace WEBSITES.Controllers
{
    public class ProductController : Controller
    {
        private readonly DBCONTEXT _db;
        private readonly IWebHostEnvironment _env;

        public ProductController(DBCONTEXT db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = _db.Categories.ToList();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile ImageUrl)
        {
            ModelState.Remove("Category"); // This is potentially risky; ensure it's required

            if (ModelState.IsValid)
            {
                if (ImageUrl != null && ImageUrl.Length > 0)
                {
                    try
                    {
                        // Handle image upload
                        product.ImageUrl = await SaveUploadedFileAsync(ImageUrl);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Image upload failed: {ex.Message}");
                        ViewData["Categories"] = _db.Categories.ToList();
                        return View(product);
                    }
                }

                // Add the product to the database
                _db.Products.Add(product);
                await _db.SaveChangesAsync();

                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }

            // If model state is invalid, return view with current model
            ViewData["Categories"] = _db.Categories.ToList();
            return View(product);
        }

        // GET: Product/Index
        public IActionResult Index()
        {
            var products = _db.Products.Include(p => p.Category).ToList();
            return View(products);
        }

        public async Task<IActionResult> Edit(int id)
        {
            // Get the product with the specified ID from the database
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            // Populate the ViewData with categories for the dropdown
            ViewData["Categories"] = _db.Categories.ToList();

            // Return the view with the existing product data
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile ImageUrl)
        {
            // Get the product with the specified ID from the database
            var existingProduct = await _db.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            // Remove Category from ModelState validation (if not required)
            ModelState.Remove("Category");

            // Update product properties with new values (except potentially ID)
            existingProduct.Name = product.Name;
            existingProduct.ExpiryDate = product.ExpiryDate;
            existingProduct.CategoryId = product.CategoryId;
            // ... (update other properties as needed)

            if (ModelState.IsValid)
            {
                if (ImageUrl != null && ImageUrl.Length > 0)
                {
                    try
                    {
                        // Handle image upload, potentially update product.ImageUrl
                        existingProduct.ImageUrl = await SaveUploadedFileAsync(ImageUrl);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Image upload failed: {ex.Message}");
                        ViewData["Categories"] = _db.Categories.ToList();
                        return View(existingProduct);
                    }
                }

                // Update the product in the database
                _db.Products.Update(existingProduct);
                await _db.SaveChangesAsync();

                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }

            // If model state is invalid, return view with existing product data
            ViewData["Categories"] = _db.Categories.ToList();
            return View(existingProduct);
        }


        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                TempData["success"] = "Product deleted successfully";
            }
            else
            {
                TempData["error"] = "Product not found";
            }

            return RedirectToAction("Index");
        }

        private async Task<string> SaveUploadedFileAsync(IFormFile file)
        {
            var uploadFolder = Path.Combine(_env.WebRootPath, "images");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filepath = Path.Combine(uploadFolder, filename);

            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filename;
        }
    }
}
