namespace CompositeWeb.Domain.DTOs.Request.User;

public record RequestUserDtoUpdate(
    Guid Id,
    string Name,
    string Email,
    string Password);