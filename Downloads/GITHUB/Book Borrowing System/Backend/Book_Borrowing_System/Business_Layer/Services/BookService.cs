using System.Collections.Generic;
using Business_Layer.IServices;
using Data_Access_Layer.IRepository;
using Shared_Layer.DTOs;
using Data_Access_Layer.Modals;

namespace Business_Layer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookDto> GetBooks()
        {
            var books = _bookRepository.GetBooks();
            return MapToBookDtoList(books);
        }

        public BookDto GetBookById(Guid id)
        {
            var book = _bookRepository.GetBookById(id);
            return MapToBookDto(book);
        }

        public BookDto CreateBook(BookDto bookDto)
        {
            var bookEntity = MapToBookEntity(bookDto);
            var createdBook = _bookRepository.AddBook(bookEntity);
            return MapToBookDto(createdBook);
        }

        public BookDto UpdateBook(Guid id, BookDto bookDto)
        {
            var existingBook = _bookRepository.GetBookById(id);

            if (existingBook == null)
            {
                return null; // Handle not found scenario
            }

            // Update existingBook properties with values from bookDto
            existingBook.Name = bookDto.Name;
            existingBook.Rating = bookDto.Rating;
            existingBook.Author = bookDto.Author;
            existingBook.Genre = bookDto.Genre;
            existingBook.IsBookAvailable = bookDto.IsBookAvailable;
            existingBook.Description = bookDto.Description;
            existingBook.LentByUserId = bookDto.LentByUserId;
            existingBook.CurrentlyBorrowedById = bookDto.CurrentlyBorrowedById;

            var updatedBook = _bookRepository.UpdateBook(existingBook);
            return MapToBookDto(updatedBook);
        }

        public BookDto DeleteBook(Guid id)
        {
            var deletedBook = _bookRepository.DeleteBook(id);
            return MapToBookDto(deletedBook);
        }

        // Helper method for mapping from Book entity to BookDto
        private BookDto MapToBookDto(Book book)
        {
            if (book == null)
            {
                return null;
            }

            return new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Rating = book.Rating,
                Author = book.Author,
                Genre = book.Genre,
                IsBookAvailable = book.IsBookAvailable,
                Description = book.Description,
                LentByUserId = book.LentByUserId,
                CurrentlyBorrowedById = book.CurrentlyBorrowedById
            };
        }

        // Helper method for mapping from Book entities list to List<BookDto>
        private List<BookDto> MapToBookDtoList(IEnumerable<Book> books)
        {
            var bookDtoList = new List<BookDto>();
            foreach (var book in books)
            {
                var bookDto = MapToBookDto(book);
                bookDtoList.Add(bookDto);
            }
            return bookDtoList;
        }

        // Helper method for mapping from BookDto to Book entity
        private Book MapToBookEntity(BookDto bookDto)
        {
            return new Book
            {
                Name = bookDto.Name,
                Rating = bookDto.Rating,
                Author = bookDto.Author,
                Genre = bookDto.Genre,
                IsBookAvailable = bookDto.IsBookAvailable,
                Description = bookDto.Description,
                LentByUserId = bookDto.LentByUserId,
                CurrentlyBorrowedById = bookDto.CurrentlyBorrowedById
            };
        }
        public BookDto BorrowBook(Guid bookId, Guid borrowingUserId)
        {
            var book = _bookRepository.GetBookById(bookId);

            if (book == null || !book.IsBookAvailable)
            {
                // Book not found or already borrowed
                
                return null;
            }

            // Update the book properties
            book.IsBookAvailable = false;
           
            book.CurrentlyBorrowedById = borrowingUserId.ToString();

            // Update the book in the repository
            var updatedBook = _bookRepository.UpdateBook(book);

            // You may need to map the entity to a DTO before returning it
            return MapToBookDto(updatedBook);
        }
        public BookDto ReturnBook(Guid bookId)
        {
            var book = _bookRepository.GetBookById(bookId);

            if (book == null)
            {
                return null; // Or throw an exception based on your design
            }

            // Implement the logic to update the book's BorrowedByUserId to null
            book.CurrentlyBorrowedById = null;

            book.IsBookAvailable = true;

            // Save the changes to the repository
            var updatedBook=_bookRepository.UpdateBook(book);

            // Map the updated book to a DTO and return it
            return MapToBookDto(updatedBook);

        }
        public BookDto RateBook(Guid bookId, double rating)
        {
            var book = _bookRepository.GetBookById(bookId);

            if (book == null)
            {
                return null; // Or throw an exception, depending on your error handling strategy
            }

            // Perform the logic to update the book's rating
            book.Rating = rating;

            // Save the changes to the repository
            _bookRepository.UpdateBook(book);

            // Return the updated book
            return MapToBookDto(book);
        }
    }
}
