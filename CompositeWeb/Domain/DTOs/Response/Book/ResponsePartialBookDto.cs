using CompositeWeb.Domain.Models;

namespace CompositeWeb.Domain.DTOs.Response.Book;

public record ResponsePartialBookDto(
    Guid Id,
    string Title,
    string Image,
    List<Chapter> TwoLastestChapters)
{
}