using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;

namespace MajornaGameStore.Api.Extensions;

public static class EventTypeExtension
{
    public static IEndpointRouteBuilder MapEventTypeEndPoints(this IEndpointRouteBuilder app)
    {

        var group = app.MapGroup("/eventTypes");


        group.MapPost("/", AddEventType).RequireAuthorization(policy => policy.RequireRole("Administrator")); ;
        return app;
    }

    public static async Task<IResult> AddEventType(EventTypeService eventTypeService, EventType eventType)
    {
        var newEventType = await eventTypeService.AddAsync(eventType);

        return Results.Ok(newEventType);
    }
}

