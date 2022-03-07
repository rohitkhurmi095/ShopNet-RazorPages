using Microsoft.EntityFrameworkCore;
using ShopNet.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopNet.Web.Data
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
