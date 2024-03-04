using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> objCatList = _db.Categories.ToList();
            return View(objCatList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            // Custom Error Message
            if (obj.DisplayOrder <= _db.Categories.Count())
            {
                ModelState.AddModelError("DisplayOrder", "The Display Order must be more than the current amount of elements");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
