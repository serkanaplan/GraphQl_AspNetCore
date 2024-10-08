using GraphQl_AspNetCore.Models;

namespace GraphQl_AspNetCore.Abstractions.Services;

public interface IBookService
{
    Task<Book> AddBookAsync(Book entity);
    Task<List<Book>> GetAllBooksAsync();
    Task<List<Book>> GetAllBooksByAuthorAsync(int authorId);
    Task<Book> GetBookByIdAsync(int id);
}
