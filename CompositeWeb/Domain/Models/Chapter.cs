using System.ComponentModel.DataAnnotations.Schema;

namespace CompositeWeb.Domain.Models;

public class Chapter
{
    public string Title { get; set; }
    public string Describe { get; set; }
    public List<string> Images { get; set; }
    public double NumberOfChapter { get; set; }
    public double PreviousChapter { get; set; }
    public double NextChapter { get; set; }

    public Chapter(string title, string describe, double numberOfChapter)
    {
        Title = title;
        Describe = describe;
        Images = new List<string>();
        NumberOfChapter = numberOfChapter;
        PreviousChapter = 0.0; //add logic
        NextChapter = 0.0; //add logic
    }
}