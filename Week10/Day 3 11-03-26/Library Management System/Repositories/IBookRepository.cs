using LibraryDemo.Models;
using System.Collections.Generic;

namespace LibraryDemo.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<BookModel> GetAllBooks();
        BookModel GetBookById(int id);
    }
}