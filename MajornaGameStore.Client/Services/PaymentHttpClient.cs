using System.Net.Http.Json;
using MajornaGameStore.Shared.CreatePayments;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;
using Microsoft.AspNetCore.Components.Routing;

namespace MajornaGameStore.Client.Services;

//Detta är en service
public class PaymentHttpClient : IPaymentHttpClient
{
    private readonly HttpClient _httpClient;

    public PaymentHttpClient(HttpClient htpClient)
    {
        _httpClient = htpClient;
    }

    public async Task<string> CreatePayment(CreatePaymentRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"/payments", request);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var checkoutResponse = await response.Content.ReadFromJsonAsync<CreateResponse>();
        return checkoutResponse?.CheckoutUrl;
    }
}