using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mission6_Cowart.Models
{
    public class MovieFormContext : DbContext     //inherit from dbcontext, may need to click on lightbulb and connect to line 1 to get to work
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)    //constructor
        {

        }

        //build table/make database set
        public DbSet<Movies> Movies { get; set; }
        //    ^call the class//^    here is table name

        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)      //seed data
        {
            modelBuilder.Entity<Categories>().HasData(

                new Categories { CategoryId = 1, CategoryName = "Miscellaneous" },
                new Categories { CategoryId = 2, CategoryName = "Drama" },
                new Categories { CategoryId = 3, CategoryName = "Television" },
                new Categories { CategoryId = 4, CategoryName = "Horror/Suspense" },
                new Categories { CategoryId = 5, CategoryName = "Comedy" },
                new Categories { CategoryId = 6, CategoryName = "Family" },
                new Categories { CategoryId = 7, CategoryName = "Action/Adventure" },
                new Categories { CategoryId = 8, CategoryName = "VHS" }
                );
        }
    }        
}
