using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDBContext dbContext)
        {
            _db = dbContext;
        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(Category.Id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["Success"] = "Delete Successful";
                return RedirectToPage("Index");
            }
            TempData["Error"] = "Delete Unsuccessful";
            return NotFound();
        }
    }
}
