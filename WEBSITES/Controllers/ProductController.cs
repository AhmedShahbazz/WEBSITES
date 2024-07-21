using Microsoft.AspNetCore.Mvc;
using WEBSITES.Data;
using WEBSITES.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WEBSITES.Controllers
{
    public class ProductController : Controller
    {
        private readonly DBCONTEXT _db;

        public ProductController(DBCONTEXT db)
        {
            _db = db;
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = _db.Categories.ToList();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            ModelState.Remove(key: "Category");
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Categories"] = _db.Categories.ToList();
            return View(product);
        }

        // GET: Product/Index
        public IActionResult Index()
        {
            var products = _db.Products.Include(p => p.Category).ToList();
            return View(products);
        }

        // GET: Product/Edit
        public IActionResult Edit(int id)
        {
            var product = _db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["Categories"] = _db.Categories.ToList();
            return View(product);
        }

        // POST: Product/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            ModelState.Remove(key: "Category");
            if (ModelState.IsValid)
            {
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Categories"] = _db.Categories.ToList();
            return View(product);
        }

        // GET: Delete
        public IActionResult Delete(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Delete
        [HttpPost]
        public IActionResult Delete(Product obj)
        {
            var product = _db.Products.Find(obj.Id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
