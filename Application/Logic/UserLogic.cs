using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto userToCreate)
    {
        User? existing = await userDao.GetByUsernameAsync(userToCreate.Username);
        if (existing != null)
            throw new Exception("Username already taken!");
        
        //TODO validate data here
        
        User toCreate = new User()
        {
            Username = userToCreate.Username,
            Password = userToCreate.Password,
            SecurityLevel = 1
        };

        User created = await userDao.CreateAsync(toCreate);
        return created;
    }

    public Task<IEnumerable<User>> GetAsync(UserSearchParametersDto userSearchParameters)
    {
        return userDao.GetAsync(userSearchParameters);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        return userDao.GetByIdAsync(id);
    }

    public async Task UpdateAsync(UserUpdateParametersDto userUpdateParameters)
    {
        User? existing = await userDao.GetByIdAsync(userUpdateParameters.Id);
        if (existing == null)
            throw new Exception($"Todo with ID {userUpdateParameters.Id} not found!");
        
        string usernameToUse = userUpdateParameters.Username ?? existing.Username;
        
        User updated = new ()
        {
            Id = existing.Id,
            Username = usernameToUse,
            Password = existing.Password
        };
        
        await userDao.UpdateAsync(updated);
    }

    public Task DeleteAsync(int id)
    {
        return userDao.DeleteAsync(id);
    }
}