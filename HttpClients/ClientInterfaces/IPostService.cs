using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync(int? authorId, string? authorName, string? titleContains, string? bodyContains);
    Task<Post> GetByIdAsync();
}