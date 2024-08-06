using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using WEBSITES.Data;
using WEBSITES.Models;

namespace WEBSITES.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBCONTEXT _dbContext;

        public HomeController(ILogger<HomeController> logger, DBCONTEXT dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(string? searchQuery)
        {
            // Query products including the related Category entity
            var productsList = _dbContext.Products.Include(p => p.Category).AsQueryable();

            // Filter the products based on the search query
            if (!string.IsNullOrEmpty(searchQuery))
            {
                productsList = productsList.Where(p => p.Name.Contains(searchQuery) || p.Category.Name.Contains(searchQuery));
            }

            // Convert to List and pass to the view
            return View(productsList.ToList());
        }

        public IActionResult Details(int id)
        {
            // Query a single product including the related Category entity
            var product = _dbContext.Products
                                    .Include(p => p.Category)
                                    .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // Handle the case when the product is not found
            }

            return View(product); // Pass the single product to the view
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
