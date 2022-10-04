using Application.DaoInterfaces;
using Domain;

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

    public Task<User?> GetByUsername(string username)
    {
        return Task.FromResult(context.Users.FirstOrDefault(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)));
    }
}