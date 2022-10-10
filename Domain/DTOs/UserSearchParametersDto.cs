namespace Domain.DTOs;

public class UserSearchParametersDto
{
    public string? UsernameContains { get; }

    public UserSearchParametersDto(string? usernameContains)
    {
        UsernameContains = usernameContains;
    }
}