using System.Net.Http.Json;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;
using System.Net.Http.Json;
using SharpCompress.Common;

namespace MajornaGameStore.Client.Services;

public class ClientEventsService(IHttpClientFactory factory) : IClientEventsService
{
    private readonly HttpClient _httpClient = factory.CreateClient(name:"Auth");

    public async Task<ICollection<EventDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync($"/events");

        if (response.IsSuccessStatusCode == false)
        {
            return new List<EventDto>();
        }

        var result = await response.Content.ReadFromJsonAsync<List<EventDto>>();

        return result.ToList();
    }

    public async Task<EventDto?> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/events/{id}");
        if (response.IsSuccessStatusCode == false)
        {
            return null;
        }

        var result = await response.Content.ReadFromJsonAsync<EventDto>();
        return result;

    }

    public async Task<EventDto> AddAsync(EventDto entity)
    {
        var response = await _httpClient.PostAsJsonAsync($"/events", entity);

        if (response.IsSuccessStatusCode == false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<EventDto>();
        return result;
    }

    public async Task<bool> UpdateAsync(EventDto entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"/events/{entity.Id}", entity);

        if (response.IsSuccessStatusCode == false)
            return false;

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"/events/{id}");

        if (response.IsSuccessStatusCode == false)
            return false;

        return true;
    }
}