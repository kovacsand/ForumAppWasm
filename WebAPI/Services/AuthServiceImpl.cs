using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using FileData;

namespace WebAPI.Services;

public class AuthServiceImpl : IAuthService
{
    private readonly FileContext context;

    public AuthServiceImpl(FileContext context)
    {
        this.context = context;
    }

    public Task<User> ValidateUser(string username, string password)
    {
        List<User> users = (List<User>)context.Users;
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