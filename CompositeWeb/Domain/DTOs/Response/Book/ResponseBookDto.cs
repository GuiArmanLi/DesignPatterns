using CompositeWeb.Domain.Models;

namespace CompositeWeb.Domain.DTOs.Response.Book;

public record ResponseBookDto(
    Guid Id,
    string Title,
    string Describe,
    string Image,
    List<Chapter> Chapters,
    List<Author> Author,
    List<Genres> Genres,
    List<Comment> Comments,
    bool IsBookMarked,
    int TotalBookmarked,
    int PositionInRank);