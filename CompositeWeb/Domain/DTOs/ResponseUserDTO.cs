using CompositeWeb.Domain.Models;

namespace CompositeWeb.Domain.DTOs;

public class ResponseUserDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }

    public DateOnly DateOfBirth { get; init; }
    public bool IsAdult { get; init; }
    public bool IsAccountEnabled { get; init; }
    public List<Guid> FavoriteBookId { get; init; } //adicionar put methhod para atualizar esse valor

    public static implicit operator ResponseUserDTO(User user) => new ResponseUserDTO
    {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email,
        DateOfBirth = user.DateOfBirth,
        IsAdult = user.IsAdult,
        IsAccountEnabled = user.IsAccountEnabled,
        FavoriteBookId = user.FavoriteBookId
    };
}