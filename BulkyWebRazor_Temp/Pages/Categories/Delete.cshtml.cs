using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext db;
        //when we work with razor pages we need to explicitly add bind attribute to whom we want to bind in post request.
        //[BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = db.categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category? obj = db.categories.Find(Category.Id);
            if(obj == null)
            {
                return NotFound();
            }
            db.categories.Remove(obj);
            db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
