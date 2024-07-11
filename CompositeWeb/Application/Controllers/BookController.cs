using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookRepository bookRepository) : ControllerBase
{
    [HttpGet]
    public async Task<List<Book>> FindAllBooks()
    {
        return await bookRepository.FindAllBooks();
    }

    [HttpGet("{id:guid}")]
    public Task<Book?> FindBookById(Guid request)
    {
        return bookRepository.FindBookById(request);
    }

    [HttpPost]
    public Task<Book?> RegisterBook(Book request)
    {
        return bookRepository.RegisterBook(request);
    }

    [HttpPut("{id:guid}")]
    public Task<Book?> UpdateBook(Guid id, Book request)
    {
        return bookRepository.UpdateBook(id, request);
    }

    [HttpDelete("{id:guid}")] // Corrigir deplicacao de parametro no swagger
    public Task<Book?> DeleteBook(Guid request)
    {
        return bookRepository.DeleteBook(request);
    }
}