using GraphQl_AspNetCore.Models;

namespace GraphQl_AspNetCore.Abstractions.Services;

public interface IAuthorService
{
    Task<List<Author>> GetAllAuthorsAsync();
    Task<Author> GetAuthorByIdAsync(int id);
    Task<Author> AddAuthorAsync(Author entity);
}
