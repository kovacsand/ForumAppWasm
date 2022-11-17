using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using EfcDataAccess;

namespace WebAPI.Services;

public class AuthServiceImpl : IAuthService
{
    private readonly DatabaseContext context;

    public AuthServiceImpl(DatabaseContext context)
    {
        this.context = context;
    }

    public Task<User> ValidateUser(string username, string password)
    {
        List<User> users = context.Users.ToList();
        User? existingUser = users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (existingUser == null)
            throw new Exception("User not found");

        if (!existingUser.Password.Equals(password))
            throw new Exception("Password mismatch");

        return Task.FromResult(existingUser);
    }
}