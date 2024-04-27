using System.Net.Http.Json;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Services;

public class ClientDeveloperService(IHttpClientFactory factory) : IClientDeveloperService
{
    private HttpClient _httpClient = factory.CreateClient(name: "Auth");
    public Task<ICollection<Developer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Developer?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Developer?> AddAsync(Developer entity)
    {
        var response = await _httpClient.PostAsJsonAsync($"/developers", entity);

        if (response.IsSuccessStatusCode == false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<Developer>();

        return result;
    }

    public Task<bool> UpdateAsync(Developer entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}