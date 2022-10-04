namespace Domain;

public class Post
{
    public int id { get; }
    public User poster { get; }
    public string title { get; set; }
    public string body { get; set; }
}