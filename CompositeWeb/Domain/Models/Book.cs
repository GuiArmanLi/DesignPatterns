using CompositeWeb.Domain.DTOs.Request.Book;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompositeWeb.Domain.Models;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public string Describe { get; set; }
    public string Image { get; set; }
    public List<Chapter> Chapters { get; init; }
    public int PositionInRank { get; set; }
    public List<Author> Author { get; init; }
    public List<Genres> Genres { get; init; } //Tratar enum
    public List<Comment> Comments { get; init; }
    public bool IsBookMarked { get; set; }
    public int TotalBookmarked { get; set; }
    public DateTime CreatedAt { get; init; }

    // public Book()
    // {
    //     Title = string.Empty;
    //     Describe = string.Empty;
    //     Image = string.Empty;
    //     Author = new List<Author>();
    //     Genres = new List<Genres>();
    //     Chapters = new List<Chapter>();
    //     Comments = new List<Comment>();
    //     PositionInRank = 0;
    //     IsBookMarked = false;
    //     TotalBookmarked = 0;
    //     CreatedAt = DateTime.Now;
    // }

    public Book(string title, string describe, string image, List<Genres> genres)
    {
        Title = title;
        Describe = describe;
        Image = image;
        Author = new List<Author>();
        Genres = genres;
        Chapters = new List<Chapter>();
        Comments = new List<Comment>();
        PositionInRank = new Random().Next(1, 100000); //add logic
        IsBookMarked = false;
        TotalBookmarked = 0;
        CreatedAt = DateTime.Now;
    }

    public static implicit operator Book(RequestBookDtoRegister dto) => new Book(
        dto.Title,
        dto.Describe,
        dto.Image,
        dto.Genres
    );

    public Book(string title, string describe, string image, List<Author> authors, List<Genres> genres,
        List<Chapter> chapters)
    {
        Title = title;
        Describe = describe;
        Image = image;
        Author = authors;
        Genres = genres;
        Chapters = chapters;
        Comments = new List<Comment>();
        PositionInRank = new Random().Next(1, 100000); //add logic
        IsBookMarked = false;
        TotalBookmarked = 0;
        CreatedAt = DateTime.Now;
    }
}