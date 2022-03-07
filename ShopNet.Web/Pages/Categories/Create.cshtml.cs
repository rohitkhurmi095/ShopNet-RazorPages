using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopNet.Web.Data;
using ShopNet.Web.Model;

namespace ShopNet.Web.Pages.Categories
{
    //[BindProperties]: bind all the properties from controller -> UI
    //[BindProperty]: bind individual property from controller -> UI
    [BindProperties]
    public class CreateModel : PageModel
    {
        //DbContext
        private readonly AppDbContext _db;

        //Constructor
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }

        //Category
        public Category Category { get; set; }

        public void OnGet()
        {
        }


        //CREATE Category
        //----------------
        public async Task<IActionResult> OnPost(Category category)
        {
            if (ModelState.IsValid)
            {
                //Add category to db & saveChanges
                await _db.Category.AddAsync(category);
                await _db.SaveChangesAsync();

                //Success message
                TempData["success"] = "Category added Successfully!";

                //After adding category -> return back to Categories page
                return RedirectToPage("Index");
            }

            //Error Message
            TempData["error"] = "Error! Add Category";

            //If model is Invalid -> return on same page
            return Page();

        }

    }
}
