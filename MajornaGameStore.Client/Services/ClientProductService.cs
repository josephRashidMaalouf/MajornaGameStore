using System.Net.Http.Json;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Services;

public class ClientProductService(IHttpClientFactory factory) : IClientProductService
{
    private readonly HttpClient _httpClient = factory.CreateClient(name:"Auth");
    public async Task<ICollection<ProductDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync($"/products");

        if (response.IsSuccessStatusCode == false)
            return new List<ProductDto>();

        var result = await response.Content.ReadFromJsonAsync<List<ProductDto>>();

        return result.ToList();

    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/products/{id}");

        if (response.IsSuccessStatusCode == false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<ProductDto>();

        return result;
    }

    public async Task<Product?> GetFullInfoByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/products/{id}");

        if (response.IsSuccessStatusCode == false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<Product>();

        return result;
    }

    public async Task<ProductDto> AddAsync(ProductDto entity)
    {
        var response = await _httpClient.PostAsJsonAsync($"/products", entity);

        if (response.IsSuccessStatusCode == false) 
            return null;

        var result = await response.Content.ReadFromJsonAsync<ProductDto>();
        return result;
    }

    public async Task<bool> UpdateAsync(ProductDto entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"/products", entity);

        if (response.IsSuccessStatusCode == false)
            return false;

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"/products/{id}");

        if ( response.IsSuccessStatusCode == false) 
            return false;


        return true;
    }

}