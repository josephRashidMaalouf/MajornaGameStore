using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using MajornaGameStore.Shared;

namespace MajornaGameStore.Api.Extensions;


public static class UserExtenstions
{
    public static IEndpointRouteBuilder MapUserEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/user");

        //group.MapGet("/{email}", GetRoleInfoByEmail);

        
        app.MapPost("/logout", async (SignInManager<User> signInManager, object empty) =>
        {
            if (empty is not null)
            {
                await signInManager.SignOutAsync();

                return Results.Ok();
            }

            return Results.Unauthorized();
        }).RequireAuthorization();

        app.MapGet("/roles", (ClaimsPrincipal user) =>
        {
            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)user.Identity;
                var roles = identity.FindAll(identity.RoleClaimType)
                    .Select(c =>
                        new
                        {
                            c.Issuer,
                            c.OriginalIssuer,
                            c.Type,
                            c.Value,
                            c.ValueType
                        });

                return TypedResults.Json(roles);
            }

            return Results.Unauthorized();
        }).RequireAuthorization();


        return app;
    }


    //public static async Task<IResult> GetRoleInfoByEmail(UserService userService, string email)
    //{
    //    var roles = await userService.GetRolesByEmail(email);

    //    if (roles is null)
    //        return Results.NotFound($"User with email {email} does not exist");


    //    return Results.Ok(roles);
    //}
}