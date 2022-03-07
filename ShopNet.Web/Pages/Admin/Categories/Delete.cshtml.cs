using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopNet.DataAccess.Data;
using ShopNet.Domain;

namespace ShopNet.Web.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
       
        //DbContext
        private readonly AppDbContext _db;

        //Constructor
        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }

        //Category
        public Category Category { get; set; }

        //GET Category by Id (To Display)
        //-------------------
        public async Task OnGet(int Id)
        {
            Category = await _db.Category.FindAsync(Id);
        }

        //DELETE Category
        //----------------
        public async Task<IActionResult> OnPost()
        {

            //Find Category to delete From Db
            Category categoryToDelete = await _db.Category.FindAsync(Category.Id);

            if (categoryToDelete!=null)
            {
                //Delete category to db & saveChanges
                _db.Category.Remove(categoryToDelete);
                await _db.SaveChangesAsync();

                //Success message
                TempData["success"] = "Category deleted Successfully!";

                //After deleting category -> return back to Categories page
                return RedirectToPage("Index");
            }

            //Error Message
            TempData["error"] = "Error! Delete Category";

            //If model is Invalid -> return on same page
            return Page();

        }

    }
}
