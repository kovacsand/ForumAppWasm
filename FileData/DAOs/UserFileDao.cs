using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
            userId = context.Users.Max(user => user.Id) + 1;

        user.Id = userId;
        context.Users.Add(user);
        context.SaveChanges();
        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        return Task.FromResult(context.Users.FirstOrDefault(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)));
    }

    public Task<User?> GetByIdAsync(int id)
    {
        return Task.FromResult(context.Users.FirstOrDefault(user => user.Id == id));
    }

    public Task<IEnumerable<User>> GetAsync(UserSearchParametersDto userSearchParameters)
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        if (userSearchParameters.UsernameContains != null)
            users = context.Users.Where(user => user.Username.Contains(userSearchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(users);
    }

    public Task UpdateAsync(UserUpdateParametersDto userUpdateParameters)
    {
        User? existing = context.Users.FirstOrDefault(user => user.Id == userUpdateParameters.Id);
        if (existing == null)
            throw new Exception($"User with ID {userUpdateParameters.Id} not found!");
        
        context.Users.Remove(existing);
        context.Users.Add(new User
        {
            Id = userUpdateParameters.Id,
            Username = userUpdateParameters.Username
        });
        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        User? existing = context.Users.FirstOrDefault(user => user.Id == id);
        if (existing == null)
            throw new Exception($"User with id {id} not found!");

        context.Users.Remove(existing);
        context.SaveChanges();

        return Task.CompletedTask;
    }
}