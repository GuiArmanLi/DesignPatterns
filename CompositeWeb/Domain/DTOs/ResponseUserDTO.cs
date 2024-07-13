using CompositeWeb.Domain.Models;

namespace CompositeWeb.Domain.DTOs;

public class ResponseUserDTO
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsAccountEnabled { get; set; }
    public List<Guid> FavoriteBookId { get; init; } //adicionar put methhod para atualizar esse valor

    public static implicit operator ResponseUserDTO(User user) => new ResponseUserDTO
    {
        Name = user.Name,
        Email = user.Email,
        Password = user.Password,
        IsAccountEnabled = user.IsAccountEnabled,
        FavoriteBookId = user.FavoriteBookId,
    };
}