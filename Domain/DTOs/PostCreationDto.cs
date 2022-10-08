namespace Domain.DTOs;

public class PostCreationDto
{
    public int AuthorId { get; }
    public string Title { get; }
    public string Body { get;  }

    public PostCreationDto(int authorId, string title, string body)
    {
        AuthorId = authorId;
        Title = title;
        Body = body;
    }
}