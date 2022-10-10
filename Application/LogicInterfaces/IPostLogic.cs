using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync(PostSearchParametersDto postSearchParameters);
    Task UpdateAsync(PostUpdateParametersDto postUpdateParameters);
    Task DeleteAsync(int id);
}