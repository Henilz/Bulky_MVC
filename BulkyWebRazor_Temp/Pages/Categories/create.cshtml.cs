using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    //we can add this to bind all the properties mentioned explicitly on post request.
    [BindProperties]
    public class createModel : PageModel
    {
        private readonly ApplicationDBContext db;
        //when we work with razor pages we need to explicitly add bind attribute to whom we want to bind in post request.
        //[BindProperty]
        public Category Category { get; set; }
        public createModel(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            db.categories.Add(Category);
            db.SaveChanges();
            TempData["success"] = "Category created successfully";
            //in here we will use this return 
            return RedirectToPage("Index");
        }
    }
}
