using System.Net.Http.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.ClientImplementations;

public class PostServiceImpl : IPostService
{
    private readonly HttpClient client;

    public PostServiceImpl(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreateAsync(PostCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/posts", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception(result);
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Post> GetByIdAsync()
    {
        throw new NotImplementedException();
    }
}