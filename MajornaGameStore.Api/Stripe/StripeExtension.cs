using MajornaGameStore.Shared.CreatePayments;
using Microsoft.AspNetCore.Routing;
using Stripe;
using Stripe.Checkout;
using Product = Stripe.Product;

namespace MajornaGameStore.Api.Stripe;

public static class StripeExtension
{
    public static void AddPaymentsApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<StripeConfig>().BindConfiguration(nameof(StripeConfig));

        services.AddScoped<StripeClient>();
    }

    public static IEndpointRouteBuilder MapPaymentsEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/payments");

        group.MapPost("/", CreateOnePayment);
        //TODO: ADD MApPost for WebHooks after sprint 1

        return app;
    }

    private static async Task<IResult> CreateOnePayment(CreatePaymentRequest request, StripeClient client)
    {
        var checkoutUrl = await client.Checkout(request);

        var ok = new CreateResponse()
        {
            CheckoutUrl = checkoutUrl
        };

        return Results.Ok(ok);
    }

    
}