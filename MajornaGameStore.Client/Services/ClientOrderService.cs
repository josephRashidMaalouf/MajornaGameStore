using System.Net.Http.Json;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Services;

public class ClientOrderService(HttpClient httpClient) : IClientOrderService
{
    private readonly HttpClient _httpClient = httpClient;
    public Task<ICollection<OrderDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderDto?> AddAsync(OrderDto entity)
    {
        var response = await httpClient.PostAsJsonAsync($"/orders", entity);

        if (response.IsSuccessStatusCode == false)
            return null;

        var orderWithIdFromDb = await response.Content.ReadFromJsonAsync<OrderDto>();

        return orderWithIdFromDb;
    }

    public Task<bool> UpdateAsync(OrderDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}