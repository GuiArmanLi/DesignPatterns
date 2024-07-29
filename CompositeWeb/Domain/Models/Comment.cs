namespace CompositeWeb.Domain.Models;

public class Comment
{
    public Guid UserId { get; init; }
    public string Content { get; set; }
    public int VoteUp { get; set; }
    public int VoteDown { get; set; }
    public List<Comment> Reply { get; init; }
    public DateTime CreatedAt { get; init; }

    public Comment()
    {
        UserId = Guid.Empty;
        Content = string.Empty;
        VoteUp = 0;
        VoteDown = 0;
        Reply = new List<Comment>();
        CreatedAt = DateTime.Now;
    }

    public Comment(Guid userId, string content)
    {
        UserId = userId;
        Content = content;
        VoteUp = 0;
        VoteDown = 0;
        Reply = new List<Comment>();
        CreatedAt = DateTime.Now;
    }
}