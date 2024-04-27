using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;
using System.Net.Http.Json;

namespace MajornaGameStore.Client.Services;

public class ClientPublisherService(IHttpClientFactory factory) : IClientPublisherService
{
    private HttpClient _httpClient = factory.CreateClient(name: "Auth");

    public Task<ICollection<Publisher>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Publisher?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Publisher> AddAsync(Publisher entity)
    {
        var response = await _httpClient.PostAsJsonAsync($"/publishers", entity);

        if (response.IsSuccessStatusCode == false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<Publisher>();

        return result;
    }

    public Task<bool> UpdateAsync(Publisher entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}