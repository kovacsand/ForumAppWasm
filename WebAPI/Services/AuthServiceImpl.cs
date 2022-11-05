using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace WebAPI.Services;

public class AuthServiceImpl : IAuthService
{
    private readonly IUserLogic userLogic;

    public AuthServiceImpl(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    public Task<User> ValidateUser(string username, string password)
    {
        IEnumerable<User> users = userLogic.GetAsync(new UserSearchParametersDto(username)).Result;
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