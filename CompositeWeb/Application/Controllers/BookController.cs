using CompositeWeb.Domain.DTOs.Request.Book;
using CompositeWeb.Domain.DTOs.Request.Book.Chapter;
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

    [HttpGet("ranking")]
    public Task<IActionResult> FindBookOrderByRanking()
    {
        return service.FindBookOrderByRankingAsync();
    }

    [HttpPost("partial")]
    public Task<IActionResult> RegisterPartialBook(RequestBookDtoRegister request)
    {
        return service.RegisterBook(request);
    }

    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateBook(Guid id, RequestBookDtoUpdate request)
    {
        return service.UpdateBook(id, request);
    }

    [HttpPatch("addNewChapter")]
    public Task<IActionResult> AddNewChapter(Guid id, ResquestChapterDtoRegister chapter)
    {
        return service.AddNewChapterAsync(id, chapter);
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteBook(Guid id)
    {
        return service.DeleteBook(id);
    }

    [HttpDelete]
    public Task<IActionResult> DeleteChapter(Guid bookId, double numberOfChapter)
    {
        // return service.DeleteChhapter();
        return null;
    }
}