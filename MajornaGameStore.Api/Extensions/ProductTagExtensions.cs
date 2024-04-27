using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;

namespace MajornaGameStore.Api.Extensions;

public static class ProductTagExtensions
{
    public static IEndpointRouteBuilder MapProductTagEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/tags");

        group.MapGet("/{id}", GetByIdAsync);
        group.MapGet("/", GetAllAsync);


        return app;
    }

    private static async Task<Tag?> GetByIdAsync(TagService service, int id)
    {
        var tag = await service.GetByIdAsync(id);

        return tag;
    }
    private static async Task<List<Tag>> GetAllAsync(TagService service)
    {
        var tags = await service.GetAllAsync();

        return tags.ToList();
    }
}