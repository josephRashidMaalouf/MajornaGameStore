using System.Net.Http.Json;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Services;

public class ClientDiscountService(IHttpClientFactory factory) : IClientDiscountService
{
    private readonly HttpClient _httpClient = factory.CreateClient("Auth");
    public Task<ICollection<Discount>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Discount?> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"discounts/{id}");

        if (response.IsSuccessStatusCode == false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<Discount>();

        return result;
    }

    public Task<Discount> AddAsync(Discount entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Discount entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}