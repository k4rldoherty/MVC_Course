using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> objCatList = _categoryRepository.GetAll().ToList();
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
            if (obj.DisplayOrder <= _categoryRepository.GetAll().Count())
            {
                ModelState.AddModelError("DisplayOrder", "The Display Order must be more than the current amount of elements");
            }
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(obj);
                _categoryRepository.Save();
                TempData["Success"] = "Category Created Successfully!";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) return NotFound();
            Category category = _categoryRepository.Get(c => c.Id == id);
            if(category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(obj);
                _categoryRepository.Save();
                TempData["Success"] = "Category Edited Successfully!";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Category category = _categoryRepository.Get(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategory(int? id)
        {
            Category? category = _categoryRepository.Get(c => c.Id == id);
            if (category == null) return NotFound();
            _categoryRepository.Remove(category);
            _categoryRepository.Save();
            TempData["Success"] = "Category Deleted Successfully!";
            return RedirectToAction("Index", "Category");
        }
    }
}
