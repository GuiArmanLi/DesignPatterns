namespace CompositeWeb.Domain.Models;

//Usar depois DTO e conversao
public class Book : BaseEntity
{
    public string Title { get; set; }
    public string Describe { get; set; }
    public string Image { get; set; }
    public List<Chapter> Chapters { get; set; }
    public int PositionInRank { get; set; }
    public List<string> Author { get; set; }
    public List<Genres> Genres { get; set; }

    public List<string>?
        Comments { get; set; } // Mudar para classe comentarios e mappear ela como serealizada e descerealizda

    public bool IsBookMarked { get; set; }
    public int TotalBookmarked { get; set; }

    public Book(string title, string image) // Adicionar DTO implicito
    {
        Title = title;
        Image = image;
        Chapters = new List<Chapter>();
        Author = new List<string>(); //add classe author
        Genres = new List<Genres>();
        Comments = new List<string>(); //add logic and add calsse comments
        IsBookMarked = false;
        TotalBookmarked = 0;
        PositionInRank = 0; //add logic
    }
}