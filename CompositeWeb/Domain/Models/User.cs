using CompositeWeb.Domain.DTOs;

namespace CompositeWeb.Domain.Models;

//Usar depois DTO e conversao
public class User : BaseEntity
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsAccountEnabled { get; set; }
    public List<Guid> FavoriteBookId { get; init; } //adicionar put methhod para atualizar esse valor
    public DateTime CreatedAt { get; init; }
    
    public static implicit operator User(RequestUserDTO dto) => new User
    {
        Name = dto.Name,
        Email = dto.Email,
        Password = dto.Password,
        IsAccountEnabled = true,
        FavoriteBookId = new List<Guid>(),
        CreatedAt = DateTime.Now
    };
}