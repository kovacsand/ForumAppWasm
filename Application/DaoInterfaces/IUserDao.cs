using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParameters);
    Task UpdateAsync(UpdateUserParametersDto updateUserParameters);
    Task DeleteAsync(int id);
}