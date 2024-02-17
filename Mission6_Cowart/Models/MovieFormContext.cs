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
        public DbSet<MovieForm> MovieForm { get; set; }
    }        //      ^call the class   // ^    here is table name
}
