namespace Domain.DTOs;

public class UserCreationDto
{
    public string Username { get; }

    public UserCreationDto(string username)
    {
        Username = username;
    }
}