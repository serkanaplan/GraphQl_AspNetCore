using GraphQl_AspNetCore.Abstractions.Repositories;
using GraphQl_AspNetCore.Abstractions.Services;
using GraphQl_AspNetCore.Models;

namespace GraphQl_AspNetCore.Services;

public class AuthorService(IAuthorRepository authorRespository, IBookService bookService) : IAuthorService
{
    readonly IBookService bookService = bookService;
    readonly IAuthorRepository authorRepository = authorRespository;

    public async Task<Author> AddAuthorAsync(Author entity) => await authorRepository.AddAsync(entity);

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        var authors = await authorRepository.GetAllAsync();
        foreach (var author in authors) author.Books = await bookService.GetAllBooksByAuthorAsync(author.Id);
        return authors;
    }

    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        var author = await authorRepository.GetByIdAsync(id);
        if (author != null) author.Books = await bookService.GetAllBooksByAuthorAsync(author.Id);
        return author;
    }
}
