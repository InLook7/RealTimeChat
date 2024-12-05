using System.Net.Http.Json;
using RealTimeChat.Blazor.Handlers.Interfaces;
using RealTimeChat.Shared.Dtos;

namespace RealTimeChat.Blazor.Handlers.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserDto> CreateUser(UserDto userDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/users", userDto);
        var user = await response.Content.ReadFromJsonAsync<UserDto>();

        return user;
    }
}