using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CompositeWeb.models;

public class User
{
    [Key]
    public Guid Id { get; }
    public string Name { get; set; }
    public string Password { get; set; }

    public User(string name, string password)
    {
        Name = name;
        Password = password;
    }
}