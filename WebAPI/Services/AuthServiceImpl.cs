using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace WebAPI.Services;

public class AuthServiceImpl : IAuthService
{
    private readonly IList<User> users = new List<User>()
    {
        new User()
        {
            Username = "Andras",
            Password = "1234",
            SecurityLevel = 2
        }
    };

    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (existingUser == null)
            throw new Exception("User not found");

        if (!existingUser.Password.Equals(password))
            throw new Exception("Password mismatch");

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {
        throw new NotImplementedException();
    }
}