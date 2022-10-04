namespace Domain;

public class Post
{
    public int Id { get; }
    public User Author { get; }
    public string Title { get; set; }
    public string Body { get; set; }
}