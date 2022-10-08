using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);
    Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParameters);
    Task UpdateAsync(UpdateUserParametersDto updateUserParameters);
    Task DeleteAsync(int id);
}