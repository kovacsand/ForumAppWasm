using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsername(string username);
    Task<IEnumerable<User>> GetAsync(SearchUserParametersDto usernameContains);
    
}