namespace Domain.DTOs;

public class PostUpdateParametersDto
{
    public int Id { get; }
    public int? AuthorId { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }

    public PostUpdateParametersDto(int id)
    {
        Id = id;
    }
}