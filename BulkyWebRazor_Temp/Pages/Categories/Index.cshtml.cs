using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public List<Category> CategoryList { get; set; }

        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }

        //in razor pages we do not have to return any view as this model is directly accessible in view and 
        //this way we do not have to add any kind of return view or so with that cause we add void as return type.
        //also when we have any get or post methods in razor pages it must start with On keyword.
        public void OnGet()
        {
            CategoryList = _db.categories.ToList();
        }
    }
}
