using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;

namespace MajornaGameStore.Api.Extensions;

public static class DeveloperExtensions
{
    public static IEndpointRouteBuilder MapDeveloperEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/developers");

        group.MapGet("/{id}", GetByIdAsync);
        group.MapGet("/", GetAllAsync);
        group.MapPost("/", AddAsync);


        return app;
    }

    public static async Task<IResult> GetByIdAsync(DeveloperService service, int id)
    {
        var dev = await service.GetByIdAsync(id);

        if (dev is null)
            return Results.NotFound();

        return Results.Ok(dev);
    }

    public static async Task<IResult> GetAllAsync(DeveloperService service)
    {
        var devs = await service.GetAllAsync();

        return Results.Ok(devs);
    }

    public static async Task<IResult> AddAsync(DeveloperService service, Developer newDev)
    {
        var newDevFromDb = await service.AddAsync(newDev);

        return Results.Ok(newDevFromDb);
    }
}