using Microsoft.AspNetCore.Mvc;
using Mission6_Cowart.Models;
using SQLitePCL;
using System.Diagnostics;

namespace Mission6_Cowart.Controllers
{
    public class HomeController : Controller
    {

        private MovieFormContext _context;
        public HomeController(MovieFormContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieForm response)
        {
            _context.MovieForm.Add(response);
            _context.SaveChanges();
            return View("Confirmation", response);
        }

    }
}
