using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext db;
        //when we work with razor pages we need to explicitly add bind attribute to whom we want to bind in post request.
        //[BindProperty]
        public Category Category { get; set; }
        public EditModel(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0)
            {
                Category = db.categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.categories.Update(Category);
                db.SaveChanges();
                TempData["success"] = "Category updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
