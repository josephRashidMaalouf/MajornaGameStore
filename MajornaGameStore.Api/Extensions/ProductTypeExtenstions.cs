using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;

namespace MajornaGameStore.Api.Extensions;

public static class ProductTypeExtenstions
{
    public static IEndpointRouteBuilder MapProductTypeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/product-types");

        group.MapGet("/{id}", GetByIdAsync);
        group.MapGet("/", GetAllAsync);


        return app;
    }

    private static async Task<ProductType?> GetByIdAsync(ProductTypeService service, int id)
    {
        var type = await service.GetByIdAsync(id);

        return type;
    }
    private static async Task<List<ProductType>> GetAllAsync(ProductTypeService service)
    {
        var types = await service.GetAllAsync();

        return types.ToList();
    }


}