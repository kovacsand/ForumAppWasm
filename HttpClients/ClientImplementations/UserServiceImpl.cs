using System.Net.Http.Json;
using System.Text.Json;
using Domain;
using Domain.DTOs;
using HttpClients.ClientInterfaces;

namespace HttpClients.ClientImplementations;

public class UserServiceImpl : IUserService
{
    private readonly HttpClient client;

    public UserServiceImpl(HttpClient client)
    {
        this.client = client;
    }

    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/users", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new Exception(result);

        Console.WriteLine(result);
        User user = JsonSerializer.Deserialize<User>(result,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        return user;
    }
}