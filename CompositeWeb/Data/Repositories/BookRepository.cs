using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.Models;

namespace CompositeWeb.data.Repositories;

public class BookRepository(BaseRepository<Book> baseRepository) : IBookRepository
{
    public async Task<List<Book>> FindAllBooks()
    {
        return await baseRepository.FindAll();
    }

    public Task<Book?> FindBookById(Guid request)
    {
        return baseRepository.FindByPropertyAsync(u => u.Id == request);
    }

    public Task<Book?> RegisterBook(Book request)
    {
        return baseRepository.RegisterEntityAsync(request, b => b.Title == request.Title);
    }

    public Task<Book?> UpdateBook(Guid id, Book request)
    {
        return baseRepository.UpdateEntityAsync(id, request);
    }

    public Task<Book?> DeleteBook(Guid request)
    {
        return baseRepository.DeleteEntityByIdAsync(request);
    }
}