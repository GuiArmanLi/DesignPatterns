using CompositeWeb.Domain.DTOs.Request.Book;

namespace CompositeWeb.Domain.Models;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public string Describe { get; set; }
    public string Image { get; set; }
    public List<Chapter> Chapters { get; init; }
    public int NumberOfChapters { get; set; }
    public int PositionInRank { get; set; }
    public List<Author> Author { get; init; }
    public List<Genres> Genres { get; init; } //Tratar enum
    public List<Comment> Comments { get; init; }
    public bool IsBookMarked { get; set; }
    public int TotalBookmarked { get; set; }
    public DateTime CreatedAt { get; init; }

    public Book(string title, string describe, string image, List<Author> authors, List<Genres> genres,
        List<Chapter> chapters)
    {
        Title = title;
        Describe = describe;
        Image = image;
        Author = authors;
        Genres = genres;
        Chapters = chapters;
        NumberOfChapters = chapters.Count;
        PositionInRank = int.MaxValue;
        Comments = new List<Comment>();
        IsBookMarked = false;
        TotalBookmarked = 0;
        CreatedAt = DateTime.Now;
    }

    public static implicit operator Book(RequestBookDtoRegister dto) => new Book(
        dto.Title,
        dto.Describe,
        dto.Image,
        dto.Authors,
        dto.Genres,
        dto.Chapters.ConvertAll(c =>
            new Chapter(c.Title, c.Images,
                c.NumberOfChapter != 0 && c.NumberOfChapter <= dto.Chapters.Count
                    ? c.NumberOfChapter
                    : dto.Chapters.Count))
    );

    public Book(string title, string describe, string image)
    {
        Title = title;
        Describe = describe;
        Image = image;
    }

    public static implicit operator Book(RequestBookDtoUpdate dto) => new Book(
        dto.Title,
        dto.Describe,
        dto.Image
    );
}