using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;
using Microsoft.AspNetCore.Builder;

namespace MajornaGameStore.Api.Extensions;

public static class PublisherExtenstions
{
    public static IEndpointRouteBuilder MapPublisherEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/publishers");

        group.MapGet("/{id}", GetByIdAsync);
        group.MapGet("/", GetAllAsync);
        group.MapPost("/", AddAsync);


        return app;
    }

    public static async Task<IResult> GetByIdAsync(PublisherService service, int id)
    {
        var pub = await service.GetByIdAsync(id);

        if (pub is null)
            return Results.NotFound();

        return Results.Ok(pub);
    }

    public static async Task<IResult> GetAllAsync(PublisherService service)
    {
        var pubs = await service.GetAllAsync();

        return Results.Ok(pubs);
    }

    public static async Task<IResult> AddAsync(PublisherService service, Publisher newPublisher)
    {
        var newPubFromDb = await service.AddAsync(newPublisher);

        return Results.Ok(newPubFromDb);
    }
}