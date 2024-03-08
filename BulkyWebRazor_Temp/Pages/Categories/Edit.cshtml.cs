using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public Category Category { get; set; }
        public EditModel(ApplicationDBContext dbContext)
        {
            _db = dbContext;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0) Category = _db.Categories.Find(id);
        }

        public IActionResult OnPost() 
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["Success"] = "Edit Successful";
                return RedirectToPage("Index");
            }

            TempData["Error"] = "Edit Unsuccessful";

            return Page();
        }
    }
}
