using System.Net.Http.Json;
using System.Text.Json;
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

    public async Task<IEnumerable<Post>> GetAsync(int? authorId, string? authorName, string? titleContains, string? bodyContains)
    {
        HttpResponseMessage response = await client.GetAsync("/posts");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception(result);

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(result,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        return posts;
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"posts/{id}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception(result);

        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        return post;
    }
}