using CompositeWeb.Domain.DTOs.Request.Book.Chapter;

namespace CompositeWeb.Domain.Models;

public class Chapter
{
    public string Title { get; set; }
    public List<string> Images { get; init; }
    public double NumberOfChapter { get; init; }
    public double PreviousChapter { get; init; }
    public double NextChapter { get; set; }
    public DateTime CreatedAt { get; init; }

    public Chapter(string title, List<string> images, double numberOfChapter)
    {
        CreatedAt = DateTime.Now;
        Title = title;
        Images = images;
        NumberOfChapter = numberOfChapter;
        PreviousChapter = 0.0; //add logic
        NextChapter = 0.0; //add logic
        CreatedAt = DateTime.Now;
    }

    public static implicit operator Chapter(ResquestChapterDtoRegister dto) => new Chapter(
        dto.Title,
        dto.Images,
        dto.NumberOfChapter
    );
}