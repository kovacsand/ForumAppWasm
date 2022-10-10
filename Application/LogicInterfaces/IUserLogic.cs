using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);
    Task<IEnumerable<User>> GetAsync(UserSearchParametersDto userSearchParameters);
    Task<User?> GetByIdAsync(int id);
    Task UpdateAsync(UserUpdateParametersDto userUpdateParameters);
    Task DeleteAsync(int id);
}