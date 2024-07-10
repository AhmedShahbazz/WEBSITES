using Microsoft.AspNetCore.Mvc;
using WEBSITES.Data;
using WEBSITES.Models;

namespace WEBSITES.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DBCONTEXT _db;
        public CategoryController(DBCONTEXT db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoriesList = _db.Categories.ToList();
            return View(objCategoriesList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {

            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
