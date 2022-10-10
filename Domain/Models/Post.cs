namespace Domain;

public class Post
{
    public Post(User author, string title, string body)
    {
        Author = author;
        Title = title;
        Body = body;
    }

    public int Id { get; set; }
    public User Author { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}