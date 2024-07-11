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
        return baseRepository.FindByProperty(u => u.Id == request);
    }

    public Task<Book?> RegisterBook(Book request)
    {
        return baseRepository.RegisterEntity(request, b => b.Title == request.Title);
    }

    public Task<Book?> UpdateBook(Guid id, Book request)
    {
        return baseRepository.UpdateEntity(id, request);
    }

    public Task<Book?> DeleteBook(Guid request)
    {
        return baseRepository.DeleteEntityById(request);
    }
}