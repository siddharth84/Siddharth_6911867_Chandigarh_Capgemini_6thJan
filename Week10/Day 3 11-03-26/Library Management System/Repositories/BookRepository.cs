using LibraryDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryDemo.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static List<BookModel> books = new List<BookModel>()
        {
            new BookModel { BookId = 1, Title = "The Alchemist", Author = "Paulo Coelho"},
            new BookModel { BookId = 2, Title = "1984", Author = "George Orwell"},
            new BookModel { BookId = 3, Title = "Pride and Prejudice", Author = "Jane Austen"}
        };

        public IEnumerable<BookModel> GetAllBooks()
        {
            return books;
        }

        public BookModel GetBookById(int id)
        {
            return books.FirstOrDefault(b => b.BookId == id);
        }
    }
}