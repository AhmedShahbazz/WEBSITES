using Microsoft.AspNetCore.Mvc;
using WEBSITES.Data;
using WEBSITES.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WEBSITES.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class AJAXXController : Controller
    {
        private readonly DBCONTEXT _db;

        public AJAXXController(DBCONTEXT db)
        {
            _db = db;
        }

        // Index Action for displaying the list of categories
        public IActionResult Index()
        {
            return View();
        }

        // Create Action for handling form submission via AJAX
        [HttpPost]
        public IActionResult Create(AJAXX obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                return Json(new { success = false, message = "The DisplayOrder and Name cannot be the same" });
            }
            if (ModelState.IsValid)
            {
                _db.AJAXX.Add(obj);
                _db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Validation error" });
        }

        // Edit Action for displaying the edit category form (not AJAX)
        public IActionResult Edit(int id)
        {
            var AJAXX = _db.AJAXX.Find(id);
            if (AJAXX == null)
            {
                return NotFound();
            }
            return View(AJAXX);
        }

        // Edit Action for handling form submission via AJAX
        [HttpPost]
        public IActionResult Edit(AJAXX obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                return Json(new { success = false, message = "The DisplayOrder and Name cannot be the same" });
            }
            if (ModelState.IsValid)
            {
                _db.AJAXX.Update(obj);
                _db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Validation error" });
        }

        // Delete Action for handling the deletion via AJAX
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var AJAXX = _db.AJAXX.Find(id);
            if (AJAXX == null)
            {
                return Json(new { success = false, message = "Category not found" });
            }

            _db.AJAXX.Remove(AJAXX);
            _db.SaveChanges();
            return Json(new { success = true });
        }

        // Action for fetching the list of categories via AJAX
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            var categories = _db.AJAXX.OrderBy(c => c.DisplayOrder).ToList();
            return Json(categories);
        }
    }
}
