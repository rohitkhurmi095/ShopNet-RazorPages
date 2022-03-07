using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopNet.DataAccess.Data;
using ShopNet.Domain;

namespace ShopNet.Web.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        //DbContext
        private readonly AppDbContext _db;
        
        //Constructor
        public IndexModel(AppDbContext db)
        {
            _db = db;
        }


        //Categories
        public IEnumerable<Category> Cagtegories { get; set; }


        //GET ALL Categories
        //-------------------
        public async Task OnGet()
        {
            Cagtegories = await _db.Category.ToListAsync();

            //Total Records
            TempData["TotalCategories"] = Cagtegories.Count();
        }
    }
}
