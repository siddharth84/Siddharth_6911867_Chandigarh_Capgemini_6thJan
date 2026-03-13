using Microsoft.AspNetCore.Mvc;
using LibraryDemo.Repositories;

namespace LibraryDemo.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        // GET: /Books
        public IActionResult Index()
        {
            var books = _repository.GetAllBooks();
            return View(books);
        }

        // GET: /Books/Details/1
        public IActionResult Details(int id)
        {
            var book = _repository.GetBookById(id);

            if (book == null)
                return NotFound();

            return View(book);
        }
    }
}