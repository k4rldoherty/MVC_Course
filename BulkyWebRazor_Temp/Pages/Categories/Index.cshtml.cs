using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;

        public List<Category> catList { get; set; }

        public IndexModel(ApplicationDBContext db)
        {
            _dbContext = db;
        }
        public void OnGet()
        {
            catList = _dbContext.Categories.ToList();
        }
    }
}
