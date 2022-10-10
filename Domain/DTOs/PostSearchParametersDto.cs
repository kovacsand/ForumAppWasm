namespace Domain.DTOs;

public class PostSearchParametersDto
{
    public int? AuthorId { get; }
    public string? AuthorName { get; }
    public string? TitleContains { get; }
    public string? BodyContains { get; }
   
    public PostSearchParametersDto(int? authorId, string? authorName, string? titleContains, string? bodyContains)
    {
        AuthorId = authorId;
        AuthorName = authorName;
        TitleContains = titleContains;
        BodyContains = bodyContains;
    }
}