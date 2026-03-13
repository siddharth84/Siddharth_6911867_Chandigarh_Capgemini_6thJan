using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Data;
using UniversityManagementSystem.Models;
using System.Linq;

namespace UniversityManagementSystem.Controllers
{
    public class CoursesController : Controller
    {
        private readonly UniversityContext _context;

        public CoursesController(UniversityContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Courses.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}