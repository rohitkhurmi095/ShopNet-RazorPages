using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopNet.DataAccess.Data;
using ShopNet.Domain;

namespace ShopNet.Web.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        //DbContext
        private readonly AppDbContext _db;

        //Constructor
        public EditModel(AppDbContext db)
        {
            _db = db;
        }

        //Category
        public Category Category { get; set; }

        //GET Category by Id  (To Display)
        //------------
        public async Task OnGet(int Id)
        {
            Category = await _db.Category.FindAsync(Id);
        }

        //UPDATE Category
        //----------------
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //Update category to db & saveChanges
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();

                //Success message
                TempData["success"] = "Category updated Successfully!";

                //After updating category -> return back to Categories page
                return RedirectToPage("Index");
            }

            //Error Message
            TempData["error"] = "Error! Update Category";

            //If model is Invalid -> return on same page
            return Page();
        }


    }
}
