using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;

namespace MajornaGameStore.Api.Extensions;

public static class DiscountExtensions
{
    public static IEndpointRouteBuilder MapDiscountEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/discounts");

        group.MapGet("/{id}", GetByIdAsync);


        return app;
    }

    private static async Task<Discount?> GetByIdAsync(DiscountService service, int id)
    {
        var discount = await service.GetByIdAsync(id);

        return discount;
    }
}