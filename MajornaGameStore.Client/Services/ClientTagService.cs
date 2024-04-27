using System.Net.Http.Json;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Services;

public class ClientTagService(IHttpClientFactory factory) : IClientTagService
{
    private HttpClient _httpClient = factory.CreateClient(name: "Auth");
    public async Task<ICollection<Tag>?> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("/tags");

        if (response.IsSuccessStatusCode == false)
            return null;

        var result = await response.Content.ReadFromJsonAsync <List<Tag>>();

        return result;
    }

    public async Task<Tag?> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"tags/{id}");

        if (response.IsSuccessStatusCode == false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<Tag>();

        return result;
    }

    public Task<Tag> AddAsync(Tag entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Tag entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}