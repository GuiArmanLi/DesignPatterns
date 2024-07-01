namespace CompositeWeb.Domain.Models;

public class User(string name, string password) : BaseEntity
{
    public string Name { get; set; } = name;

    public string Password { get; set; } = password;
}