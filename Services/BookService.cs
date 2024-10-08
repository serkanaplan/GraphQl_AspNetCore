using GraphQl_AspNetCore.Abstractions.Repositories;
using GraphQl_AspNetCore.Abstractions.Services;
using GraphQl_AspNetCore.Models;

namespace GraphQl_AspNetCore.Services;

public class BookService(IBookRepository bookRepository) : IBookService
{
    readonly IBookRepository bookRepository = bookRepository;

    public async Task<Book> AddBookAsync(Book entity) => await bookRepository.AddAsync(entity);
    public async Task<List<Book>> GetAllBooksAsync() => await bookRepository.GetAllAsync();
    public async Task<Book> GetBookByIdAsync(int id) => await bookRepository.GetByIdAsync(id);
    public async Task<List<Book>> GetAllBooksByAuthorAsync(int authorId) 
    => (await bookRepository.GetAllAsync()).Where(p => p.AuthorId == authorId).ToList();
}