using GraphQl_AspNetCore.Abstractions.Repositories;
using GraphQl_AspNetCore.Models;

namespace GraphQl_AspNetCore.Repositories;


public class AuthorRepository : IAuthorRepository
{
    private readonly List<Author> _authors;

    public AuthorRepository()
    {
        _authors =
         [
            new() {Id = 1,Name = "Stephen Edwin",LastName = "King"},
            new() {Id = 1,Name = "John Ronald Reuel",LastName = "Tolkien"},
        ];
    }
    public Task<Author> AddAsync(Author entity)
    {
        entity.Id = _authors.Count + 1;
        _authors.Add(entity);

        return Task.FromResult(entity);
    }

    public Task<List<Author>> GetAllAsync() => Task.FromResult(_authors);

    public Task<Author> GetByIdAsync(int id) => Task.FromResult(_authors.Find(a => a.Id == id));
}
