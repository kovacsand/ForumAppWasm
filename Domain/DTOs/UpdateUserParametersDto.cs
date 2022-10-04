namespace Domain.DTOs;

public class UpdateUserParametersDto
{
    public int Id { get; }
    public string? Username { get; set; }

    public UpdateUserParametersDto(int id)
    {
        Id = id;
    }
}