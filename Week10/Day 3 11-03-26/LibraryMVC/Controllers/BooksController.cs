using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryMVC.Models;

namespace LibraryMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryDBContext _context;

        public BooksController(LibraryDBContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = _context.Books.Include(b => b.Author);
            return View(await books.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Isbn,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound();

            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,Isbn,AuthorId")] Book book)
        {
            if (id != book.BookId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        // POST: Books/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book != null)
                _context.Books.Remove(book);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}