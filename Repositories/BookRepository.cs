using GraphQl_AspNetCore.Abstractions.Repositories;
using GraphQl_AspNetCore.Models;

namespace GraphQl_AspNetCore.Repositories;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books;

    public BookRepository()
    {
        _books =
        [
            new() { Id = 1, Title = "The Shining (Medyum)", AuthorId = 1 },
            new() { Id = 2, Title = "Doctor Sleep (Doktor Uyku)", AuthorId = 1 },
            new() { Id = 3, Title = "Hobbit", AuthorId = 2 },
            new() { Id = 4, Title = "Lord Of The Rings (Yüzüklerin Efendisi)", AuthorId = 2 }
        ];
    }


    public Task<Book> AddAsync(Book entity)
    {
        entity.Id = _books.Count + 1;
        _books.Add(entity);

        return Task.FromResult(entity);
    }

    public Task<List<Book>> GetAllAsync() => Task.FromResult(_books);


    public Task<Book> GetByIdAsync(int id) => Task.FromResult(_books.Find(a => a.Id == id));
}
