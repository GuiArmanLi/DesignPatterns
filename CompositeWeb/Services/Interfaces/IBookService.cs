using CompositeWeb.Domain.DTOs.Request.Book;
using CompositeWeb.Domain.DTOs.Request.Book.Chapter;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Services.Interfaces;

public interface IBookService
{
    public Task<IActionResult> FindAllBooksAsync();
    public Task<IActionResult> FindAllBooksSummariesAsync();
    public Task<IActionResult> FindBookById(Guid request);
    public Task<IActionResult> FindBookOrderByRankingAsync();
    public Task<IActionResult> RegisterBook(RequestBookDtoRegister requestPartial);
    public Task<IActionResult> AddNewChapterAsync(Guid id, ResquestChapterDtoRegister chapter);
    public Task<IActionResult> UpdateBook(Guid id, RequestBookDtoUpdate request);
    public Task<IActionResult> DeleteBook(Guid request);
    public Task<IActionResult> DeleteChapter(Guid bookId, int numberOfChapter);

}