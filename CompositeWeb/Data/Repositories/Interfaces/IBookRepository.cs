using CompositeWeb.Domain.Models;

namespace CompositeWeb.Data.Repositories.Interfaces;

public interface IBookRepository
{
    public Task<List<Book>> FindAllBooks();
    public Task<Book?> FindBookById(Guid request);
    public Task<Book?> RegisterBook(Book request);
    public Task<Book?> UpdateBook(Guid id, Book request);
    public Task<Book?> DeleteBook(Guid request);
}