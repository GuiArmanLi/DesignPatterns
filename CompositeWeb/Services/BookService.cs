using System.Net;
using HttpResponse = CompositeWeb.Application.Shared.HttpResponse;
using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.DTOs.Request.Book;
using CompositeWeb.Domain.DTOs.Response.Book;
using CompositeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompositeWeb.Services;

public class BookService(IBookRepository repository) : IBookService
{
    public async Task<IActionResult> FindAllBooksAsync()
    {
        var books = await repository.FindAllBooks();

        if (books.Count == 0)
            return new HttpResponse(HttpStatusCode.OK, "Does not exist any book");

        var booksFiltered = books.Select(book => new ResponseCompletBookDto(
                book.Id,
                book.Title,
                book.Describe,
                book.Image,
                book.Chapters,
                book.Author,
                book.Genres,
                book.Comments,
                book.IsBookMarked,
                book.TotalBookmarked,
                book.PositionInRank
            )
        ).ToList();

        return new HttpResponse(HttpStatusCode.OK, booksFiltered);
    }

    public async Task<IActionResult> FindAllBooksSummariesAsync()
    {
        var books = await repository.FindAllBooks();

        if (books.Count == 0)
            return new HttpResponse(HttpStatusCode.OK, "Does not exist any book");

        var booksFiltered = books.Select(book => new ResponsePartialBookDto(
                book.Id,
                book.Title,
                book.Image,
                book.Chapters
            )
        ).ToList();

        return new HttpResponse(HttpStatusCode.OK, booksFiltered);
    }

    public async Task<IActionResult> FindBookById(Guid id)
    {
        var book = await repository.FindBookById(id);

        if (book is null)
            return new HttpResponse(HttpStatusCode.BadRequest, $"Does not exist an book with Id:{id}");

        return new HttpResponse(HttpStatusCode.OK, book);
    }

    public async Task<IActionResult> RegisterBook(RequestBookDtoRegister book)
    {
        var response = await repository.RegisterBook(book);

        if (response is null)
            return new HttpResponse(HttpStatusCode.BadRequest, $"Book with title {book.Title} already exist");

        return new HttpResponse(HttpStatusCode.Created, response);
    }

    public async Task<IActionResult> UpdateBook(Guid id, RequestBookDtoRegister book)
    {
        var response = await repository.UpdateBook(id, book);

        if (response is null)
            return new HttpResponse(HttpStatusCode.BadRequest,
                $"The {nameof(book)} is incorrect or does not exit an user with Id:{id}");

        return new HttpResponse(HttpStatusCode.Accepted, book);
    }

    public async Task<IActionResult> DeleteBook(Guid id)
    {
        var response = await repository.DeleteBook(id);

        if (response is null)
            return new HttpResponse(HttpStatusCode.BadGateway, $"Does not exit an book with Id:{id}");

        return new HttpResponse(HttpStatusCode.Accepted, $"Does not exist a Book with Id: {id}");
    }
}