using Microsoft.EntityFrameworkCore;

namespace EfCoreBookCodeFirstDemo.Models
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {
        }

        public DbSet<BookModel> Books { get; set; }
    }
}