using Microsoft.AspNetCore.Mvc;
using EfCoreBookCodeFirstDemo.Models;
using System.Linq;

namespace EfCoreBookCodeFirstDemo.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDBContext _context;

        public BookController(BookDBContext context)
        {
            _context = context;
        }

        // READ (Index)
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(BookModel book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(BookModel book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE (GET)
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }
    }
}