using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post> GetByIdAsync();
}