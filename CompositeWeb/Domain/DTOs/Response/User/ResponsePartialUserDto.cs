namespace CompositeWeb.Domain.DTOs.Response.User;

public record ResponsePartialUserDto(
    Guid Id,
    string Name,
    string Email,
    bool IsAccountEnabled);