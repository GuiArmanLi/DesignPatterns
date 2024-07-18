using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookRepository bookRepository) : ControllerBase
{
    [HttpGet]
    public Task<List<Book>> FindAllBooks()
    {
        return bookRepository.FindAllBooks();
    }

    [HttpGet("{id:guid}")]
    public Task<Book?> FindBookById(Guid id)
    {
        return bookRepository.FindBookById(id);
    }

    //adicionar comentario sobre forma do json padrao incorreta pelo swagger
    //Campo Reply deve ser uma lista vazia ao inves de "string"
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

    [HttpDelete("{id:guid}")]
    public Task<Book?> DeleteBook(Guid id)
    {
        return bookRepository.DeleteBook(id);
    }
}