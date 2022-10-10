using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(PostSearchParametersDto postSearchParameters);
    Task<Post?> GetByIdAsync(int id);
    Task UpdateAsync(Post post);
}