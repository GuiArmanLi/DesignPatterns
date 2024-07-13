using System.Runtime.InteropServices.JavaScript;

namespace CompositeWeb.Domain.Models;

public class Author
{
    public string Name { get; set; }
    public string? Biography { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    public List<Guid> IdBooks { get; init; }

    public Author()
    {
        Name = string.Empty;
        Biography = "Nothing about...";
        DateOfBirth = new DateOnly();
        Nationality = "Nothing about...";
        IdBooks = new List<Guid>();
    }

    public Author(string name)
    {
        Name = name;
        Biography = "Nothing about...";
        DateOfBirth = new DateOnly();
        Nationality = "Nothing about...";
        IdBooks = new List<Guid>();
    }

    public Author(string name, string biography, string nationality)
    {
        Name = name;
        Biography = biography;
        Nationality = nationality;
        IdBooks = new List<Guid>();
    }
}