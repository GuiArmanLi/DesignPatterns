using CompositeWeb.Domain.DTOs.Request.User;

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

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        FavoriteBookId = new List<Guid>();
    }

    public static implicit operator User(RequestUserDtoUpdate dto) => new User(
        dto.Name,
        dto.Email,
        dto.Password);

    public User(string name, string email, string password, DateOnly dateOfBirth, bool isAdult)
    {
        Name = name;
        Email = email;
        Password = password;
        DateOfBirth = dateOfBirth;
        IsAdult = isAdult;
        IsAccountEnabled = true;
        FavoriteBookId = new List<Guid>();
        CreatedAt = DateTime.Now;
    }

    public static implicit operator User(RequestUserDtoRegister dto) => new User
    (
        dto.Name,
        dto.Email,
        dto.Password,
        dto.DateOfBirth,
        DateTime.Now.Year - dto.DateOfBirth.Year >= 18 &&
        DateTime.Now.DayOfYear > dto.DateOfBirth.DayOfYear
    );
}