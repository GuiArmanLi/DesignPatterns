using CompositeWeb.Domain.Models;

namespace CompositeWeb.Domain.DTOs.Response.Book;

public record ResponseSummariesBookDto(Guid Id, string Title, string Image, List<Chapter> TwoLastChapters);