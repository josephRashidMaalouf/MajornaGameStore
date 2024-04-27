using System.Net.Http.Json;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Managers;

public class ProductManager(HttpClient httoClient) : IProductManager
{
    private readonly HttpClient _httpClient = httoClient;
    public bool ProductsLoaded { get; set; } = false;
    public List<ProductDto> Products { get; set; } = new List<ProductDto>();

    public async Task LoadProducts()
    {
        if (ProductsLoaded == false)
        {
            return;
        }

        var response = await _httpClient.GetAsync($"/products");

        if (response.IsSuccessStatusCode == false)
            return;

        var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();

        Products.AddRange(products);
    }
}