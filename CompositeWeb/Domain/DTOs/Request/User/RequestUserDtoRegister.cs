namespace CompositeWeb.Domain.DTOs.Request.User;

public record RequestUserDtoRegister(
    string Name,
    string Email,
    string Password,
    DateOnly DateOfBirth);