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
        private readonly   DBCONTEXT _dbContext;

        public HomeController(ILogger<HomeController> logger, DBCONTEXT dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            // Query products including the related Category entity
            IEnumerable<Product> productsList = _dbContext.Products.Include(p => p.Category).ToList();
            return View(productsList);
        }
        public IActionResult Details(int id)
        {
            // Query a single product including the related Category entity
            Product product = _dbContext.Products
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
