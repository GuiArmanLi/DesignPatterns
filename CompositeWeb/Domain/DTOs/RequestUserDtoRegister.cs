namespace CompositeWeb.Domain.DTOs;

public class RequestUserDtoRegister
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public RequestUserDtoRegister(string name, string email, string password, DateOnly dateOfBirth)
    {
        Name = name;
        Email = email;
        Password = password;
        DateOfBirth = dateOfBirth;
    }
}