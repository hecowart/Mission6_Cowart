using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Cowart.Models;
using SQLitePCL;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_Cowart.Controllers
{
    public class HomeController : Controller
    {

        private MovieFormContext _context;
        public HomeController(MovieFormContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()    //show home page
        {
            return View();
        }

        public IActionResult GetToKnowJoel()       //show get to know joel page
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()        //show movie submission form
        {
            ViewBag.Category = _context.Categories      //sorts category names to populate dropdown
                .OrderBy(key => key.CategoryName)
                .ToList();

            return View("MovieForm", new Movies());     //initialize new movie instance so that the id is set
        }

        [HttpPost]
        public IActionResult MovieForm(Movies response)     //post movie form
        {
            if (ModelState.IsValid)         //check to see if it's valid
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else    //invalid data, we need to resend their form to them
            {
                ViewBag.Category = _context.Categories
                .OrderBy(key => key.CategoryName)
                .ToList();

                return View(response);
            }
        }

        public IActionResult ViewCollection()   //show database table
        {
            var movieSubmission = _context.Movies
                .Include(key => key.Category) //this is like inner joining in sql
                .OrderBy(key => key.Title).ToList();

            ViewBag.Categories = _context.Movies;

            return View(movieSubmission);
        }

        [HttpGet]
        public IActionResult Edit(int id)       //edit
        {
            var movieToEdit = _context.Movies
                .Single(key => key.MovieId == id);

            ViewBag.Category = _context.Categories
                .OrderBy(key => key.CategoryName)
                .ToList();
            return View("MovieForm", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movies updatedInfo)       //update
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("ViewCollection");
        }

        [HttpGet]
        public IActionResult Delete(int id)         //send to confirmation to delete
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movies application)     //send back to database
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("ViewCollection");  
        }
    }
}
