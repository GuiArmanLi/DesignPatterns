using CompositeWeb.Domain.DTOs.Request.Book;
using CompositeWeb.Domain.Models;
using CompositeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService service)
{
    [HttpGet]
    public async Task<IActionResult> FindAllBooks()
    {
        return await service.FindAllBooksAsync();
    }

    [HttpGet("summaries")]
    public Task<IActionResult> FindAllBooksSummaries()
    {
        return service.FindAllBooksSummariesAsync();
    }

    [HttpGet("{id:guid}")]
    public Task<IActionResult> FindBookById(Guid id)
    {
        return service.FindBookById(id);
    }

    /// <summary>
    /// Reply do Json deve ser uma lista
    /// </summary>
    [HttpPost]
    public Task<IActionResult> RegisterBook(RequestBookDtoRegister request)
    {
        return service.RegisterBook(request);
    }

    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateBook(Guid id, RequestBookDtoRegister request)
    {
        return service.UpdateBook(id, request);
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteBook(Guid id)
    {
        return service.DeleteBook(id);
    }
}