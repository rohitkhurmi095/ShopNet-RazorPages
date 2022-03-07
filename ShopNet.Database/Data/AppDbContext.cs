using Microsoft.EntityFrameworkCore;
using ShopNet.Domain;

namespace ShopNet.DataAccess.Data
{
    //DbContext: for querying Database
    //pass DbContext options -> DbContext
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        //DataSet
        //--------
        public DbSet<Category> Category { get; set; }
    }
}
