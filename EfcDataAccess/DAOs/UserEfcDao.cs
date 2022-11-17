using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly DatabaseContext context;

    public UserEfcDao(DatabaseContext context)
    {
        this.context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        User? existing = context.Users.FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower()));
        return Task.FromResult(existing);    
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? existing = await context.Users.FindAsync(id);
        return existing;
    }

    public async Task<IEnumerable<User>> GetAsync(UserSearchParametersDto userSearchParameters)
    {
        IQueryable<User> usersQuery = context.Users.AsQueryable();
        if (userSearchParameters.UsernameContains != null)
            usersQuery = usersQuery.Where(u => u.Username.ToLower().Contains(userSearchParameters.UsernameContains.ToLower()));

        IEnumerable<User> result = await usersQuery.ToListAsync();
        return result;
    }

    public async Task UpdateAsync(User user)
    {
        context.ChangeTracker.Clear();
        context.Users.Update(user);
        await context.SaveChangesAsync();    
    }

    public async Task DeleteAsync(int id)
    {
        User? existing = await GetByIdAsync(id);
        if (existing == null)
            throw new Exception($"User with id {id} not found!");
        
        context.Users.Remove(existing);
        await context.SaveChangesAsync();
    }
}