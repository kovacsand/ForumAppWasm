namespace Domain.DTOs;

public class UserUpdateParametersDto
{
    public int Id { get; }
    public string? Username { get; set; }

    public UserUpdateParametersDto(int id)
    {
        Id = id;
    }
}