namespace CompositeWeb.Domain.Models;

//Usar depois DTO e conversao
public class Book : BaseEntity
{
    public string Title { get; set; }
    public string Describe { get; set; }
    public string Image { get; set; }
    public List<Chapter> Chapters { get; init; }
    public int PositionInRank { get; set; }
    public List<Author> Author { get; init; }
    public List<Genres> Genres { get; init; } //Tratar enum
    public List<Comment>? Comments { get; init; }
    public bool IsBookMarked { get; set; }
    public int TotalBookmarked { get; set; }
    public DateTime CreatedAt { get; init; }

    public Book(string title, string image) // Adicionar DTO implicito
    {
        Title = title;
        Image = image;
        Chapters = new List<Chapter>();
        Author = new List<Author>();
        Genres = new List<Genres>();
        Comments = new List<Comment>(); //add logic
        IsBookMarked = false;
        TotalBookmarked = 0;
        PositionInRank = 0; //add logic
        CreatedAt = DateTime.Now;
    }
}