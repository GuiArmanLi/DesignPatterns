using CompositeWeb.Domain.DTOs;

namespace CompositeWeb.Domain.Models;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; init; }
    public bool IsAdult { get; set; }
    public bool IsAccountEnabled { get; set; }
    public List<Guid> FavoriteBookId { get; init; } //adicionar put methhod para atualizar esse valor
    public DateTime CreatedAt { get; init; }

    public static implicit operator User(RequestUserDtoRegister dtoRegister) => new User
    {
        Name = dtoRegister.Name,
        Email = dtoRegister.Email,
        Password = dtoRegister.Password,
        DateOfBirth = dtoRegister.DateOfBirth,
        IsAdult = DateTime.Now.Year - dtoRegister.DateOfBirth.Year >= 18 &&
                  DateTime.Now.DayOfYear > dtoRegister.DateOfBirth.DayOfYear,
        IsAccountEnabled = true,
        FavoriteBookId = new List<Guid>(),
        CreatedAt = DateTime.Now
    };

    public static implicit operator User(RequestUserDtoUpdate dtoPost) => new User
    {
        Name = dtoPost.Name,
        Email = dtoPost.Email,
        Password = dtoPost.Password,
    };
}