using System.Collections.Generic;
using System.Linq;

using Data_Access_Layer.IRepository;
using Data_Access_Layer.Modals;

using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(Guid id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Book AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
            return book;
        }

        public Book DeleteBook(Guid id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return null;
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return book;
        }
    }
}
