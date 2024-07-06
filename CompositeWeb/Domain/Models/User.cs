namespace CompositeWeb.Domain.Models;

public class User : BaseEntity
{
    public string Name { get; set; }

    public string Password { get; set; }

    public User(string name, string password)
    {
        Name = name;
        Password = password;
    }

}