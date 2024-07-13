namespace CompositeWeb.Domain.Models;

public class Chapter
{
    public string Title { get; set; }
    public List<string> Images { get; init; }
    public double NumberOfChapter { get; set; }
    public double PreviousChapter { get; set; }
    public double NextChapter { get; set; }
    public DateTime CreatedAt { get; init; }


    public Chapter(string title, List<string> images, double numberOfChapter)
    {
        Title = title;
        Images = images;
        NumberOfChapter = numberOfChapter;
        PreviousChapter = 0.0; //add logic
        NextChapter = 0.0; //add logic
        CreatedAt = DateTime.Now;
    }
}