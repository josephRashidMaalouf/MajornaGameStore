using System.Net.Http.Json;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Services;

public class ClientTypeService(IHttpClientFactory factory) : IClientTypeService
{

    private readonly HttpClient _httpClient = factory.CreateClient("Auth");
    public async Task<ICollection<ProductType>?> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("product-types");

        if (response.IsSuccessStatusCode == false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<List<ProductType>>();

        return result;
    }

    public async Task<ProductType?> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/product-types/{id}");

        if (response.IsSuccessStatusCode is false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<ProductType>();

        return result;

    }

    public Task<ProductType> AddAsync(ProductType entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ProductType entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}