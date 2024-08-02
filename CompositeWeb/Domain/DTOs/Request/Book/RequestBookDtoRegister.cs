using CompositeWeb.Domain.DTOs.Request.Book.Chapter;
using CompositeWeb.Domain.Models;

namespace CompositeWeb.Domain.DTOs.Request.Book;

public record RequestBookDtoRegister
{
    public string Title { get; }
    public string Describe { get; }
    public string Image { get; }
    public List<Author> Authors { get; }
    public List<Genres> Genres { get; }
    public List<ResquestChapterDtoRegister> Chapters { get; }

    public RequestBookDtoRegister(string title, string describe, string image, List<Author>? authors,
        List<Genres>? genres, List<ResquestChapterDtoRegister>? chapters)
    {
        Title = title;
        Describe = describe;
        Image = image;

        authors ??= new List<Author>();
        Authors = authors;

        genres ??= new List<Genres>();
        Genres = genres;

        chapters ??= new List<ResquestChapterDtoRegister>();
        Chapters = chapters;
    }
};