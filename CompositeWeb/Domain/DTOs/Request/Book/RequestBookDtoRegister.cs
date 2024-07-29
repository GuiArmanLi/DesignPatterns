using CompositeWeb.Domain.Models;

namespace CompositeWeb.Domain.DTOs.Request.Book;

public record RequestBookDtoRegister(
    string Title,
    string Describe,
    string Image,
    List<Genres> Genres);