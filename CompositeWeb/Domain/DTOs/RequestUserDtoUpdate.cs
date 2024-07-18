namespace CompositeWeb.Domain.DTOs;

public class RequestUserDtoUpdate
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public RequestUserDtoUpdate(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}