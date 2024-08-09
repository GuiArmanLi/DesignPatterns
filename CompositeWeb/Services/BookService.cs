using HttpResponse = CompositeWeb.Application.Shared.HttpResponse;
using CompositeWeb.Domain.DTOs.Request.Book.Chapter;
using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.DTOs.Response.Book;
using CompositeWeb.Domain.DTOs.Request.Book;
using CompositeWeb.Services.Interfaces;
using CompositeWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CompositeWeb.Services;

public class BookService(IBookRepository repository) : IBookService
{
    public async Task<IActionResult> FindAllBooksAsync()
    {
        var books = await repository.FindAllBooks();

        if (books.Count == 0)
            return new HttpResponse(HttpStatusCode.OK, "Does not exist any book");

        var booksFiltered = books.Select(book => new ResponseBookDto(
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

        var booksFiltered = books.Select(book => new ResponseSummariesBookDto(
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
            return new HttpResponse(HttpStatusCode.NotFound, $"Does not exist an book with Id:{id}");

        return new HttpResponse(HttpStatusCode.OK, book);
    }

    public async Task<IActionResult> FindBookOrderByRankingAsync()
    {
        var books = await repository.FindAllBooks();

        if (books.Count == 0)
            return new HttpResponse(HttpStatusCode.OK, "Does not exist any book");

        var response = books.OrderBy(b => b.PositionInRank);

        return new HttpResponse(HttpStatusCode.Accepted, response, "Order by ascend");
    }


    public async Task<IActionResult> RegisterBook(RequestBookDtoRegister partialBook)
    {
        Book book = partialBook;

        book.PositionInRank = repository.FindAllBooks().Result.Count();

        var response = await repository.RegisterBook(book);

        if (response is null)
            return new HttpResponse(HttpStatusCode.BadRequest, $"Book with title {partialBook.Title} already exist");

        var idBook = response.Id;
        response.Author.ForEach(a => a.IdBooks.Add(idBook));

        return new HttpResponse(HttpStatusCode.Created, response);
    }

    public async Task<IActionResult> AddNewChapterAsync(Guid id, ResquestChapterDtoRegister chapter)
    {
        var book = await repository.FindBookById(id);

        if (book is null)
            return new HttpResponse(HttpStatusCode.NotFound, $"Does not exist a book with id: {id}");

        book.Chapters.Add(chapter);

        await repository.UpdateBook(id, book, new List<string>() { "Chapters" });

        return new HttpResponse(HttpStatusCode.Accepted, book);
    }

    public async Task<IActionResult> UpdateBook(Guid id, RequestBookDtoUpdate book)
    {
        List<string> propertiesFromObject =
            book.GetType().GetProperties().Where(p => p.Name != "Id").Select(p => p.Name).ToList();

        var response = await repository.UpdateBook(id, book, propertiesFromObject);

        if (response is null)
            return new HttpResponse(HttpStatusCode.NotFound,
                $"The {nameof(book)} is incorrect or does not exit an user with Id:{id}");

        return new HttpResponse(HttpStatusCode.Accepted, book);
    }

    public async Task<IActionResult> DeleteBook(Guid id)
    {
        var response = await repository.DeleteBook(id);

        if (response is null)
            return new HttpResponse(HttpStatusCode.NotFound, $"Does not exit an book with Id:{id}");

        return new HttpResponse(HttpStatusCode.Accepted, $"Does not exist a Book with Id: {id}");
    }

    public async Task<IActionResult> DeleteChapter(Guid bookId, double numberOfChapter)
    {
        var book = await repository.FindBookById(bookId);

        if (book is null)
            return null;

        if (numberOfChapter < 0 ||
            book.Chapters.FirstOrDefault(c => c.NumberOfChapter == numberOfChapter)
        return null;

        book.Chapters.Remove();


        return null;
    }
}