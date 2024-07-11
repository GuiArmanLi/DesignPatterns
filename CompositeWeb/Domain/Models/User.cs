namespace CompositeWeb.Domain.Models;

//Usar depois DTO e conversao
public class User : BaseEntity
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsAccountEnabled { get; set; }
    public List<Guid> IdFromFavoriteBooks { get; set; }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
        IsAccountEnabled = true;
        IdFromFavoriteBooks = new List<Guid>();
    }
}