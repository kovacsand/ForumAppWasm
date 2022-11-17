using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    public Task<User> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAsync(UserSearchParametersDto userSearchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UserUpdateParametersDto userUpdateParameters)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}