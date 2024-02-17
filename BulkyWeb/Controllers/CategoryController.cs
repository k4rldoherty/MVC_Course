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
    }
}
