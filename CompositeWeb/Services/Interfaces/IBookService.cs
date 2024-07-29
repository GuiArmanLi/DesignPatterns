using CompositeWeb.Domain.DTOs.Request.Book;
using CompositeWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Services.Interfaces;

public interface IBookService
{
    public Task<IActionResult> FindAllBooksAsync();
    public Task<IActionResult> FindAllBooksSummariesAsync();

    public Task<IActionResult> FindBookById(Guid request);

    public Task<IActionResult> RegisterBook(RequestBookDtoRegister request);

    public Task<IActionResult> UpdateBook(Guid id, RequestBookDtoRegister request);

    public Task<IActionResult> DeleteBook(Guid request);
}