using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync(PostSearchParametersDto postSearchParameters);
    Task<Post> GetByIdAsync(int id);
    Task UpdateAsync(PostUpdateParametersDto postUpdateParameters);
    Task DeleteAsync(int id);
}