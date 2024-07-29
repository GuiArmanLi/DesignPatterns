using System.Runtime.InteropServices.JavaScript;

namespace CompositeWeb.Domain.Models;

public class Author
{
    public string Name { get; set; }
    public string? Biography { get; set; }
    public DateOnly? DateOfBirth { get; init; }
    public string? Nationality { get; init; }
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
    public Author(string name, string biography)
    {
        Name = name;
        Biography = biography;
        IdBooks = new List<Guid>();
    }

    public Author(string name, string biography, string nationality)
    {
        Name = name;
        Biography = biography;
        Nationality = nationality;
        IdBooks = new List<Guid>();
    }
    
    public Author(string name, string biography, string nationality, DateOnly dateOfBirth)
    {
        Name = name;
        Biography = biography;
        Nationality = nationality;
        DateOfBirth = dateOfBirth;
        IdBooks = new List<Guid>();
    }
}