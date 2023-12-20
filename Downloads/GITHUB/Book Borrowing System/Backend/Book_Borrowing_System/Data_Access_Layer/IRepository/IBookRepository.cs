using System.Collections.Generic;
using Data_Access_Layer.Modals;


namespace Data_Access_Layer.IRepository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(Guid id);
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        Book DeleteBook(Guid id);
    }
}
