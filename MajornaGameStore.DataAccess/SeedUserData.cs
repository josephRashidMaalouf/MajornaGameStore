using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Sql;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MajornaGameStore.Shared;

public class SeedUserData
{
    private static readonly IEnumerable<SeedUser> seedUsers =
    [
        new SeedUser()
        {
            Email = "admin@gamegrottan.com",
            NormalizedEmail = "ADMIN@GAMEGROTTAN.COM",
            NormalizedUserName = "ADMIN@GAMEGROTTAN.COM",
            RoleList = ["Administrator"],
            UserName = "admin@gamegrottan.com"
        },
        new SeedUser()
        {
            Email = "user@user.user",
            NormalizedEmail = "USER@USER.USER",
            NormalizedUserName = "USER@USER.USER",
            RoleList = ["User"],
            UserName = "user@user.user"
        },
    ];

    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var context = new MajornaDbContext(serviceProvider.GetRequiredService<DbContextOptions<MajornaDbContext>>());

        //Kanske ta bort denna check
        if (context.Users.Any())
        {
            return;
        }

        var userStore = new UserStore<User>(context);
        var password = new PasswordHasher<User>();

        using var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

        string[] roles = ["Administrator", "User"];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new Role(role));
            }
        }

        using var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        foreach (var user in seedUsers)
        {
            var hashed = password.HashPassword(user, "GameGrottan2024!");
            user.PasswordHash = hashed;
            await userStore.CreateAsync(user);

            if (user.Email is not null)
            {
                var appUser = await userManager.FindByEmailAsync(user.Email);

                if (appUser is not null && user.RoleList is not null)
                {
                    await userManager.AddToRolesAsync(appUser, user.RoleList);
                }
            }
        }


        await context.SaveChangesAsync();
    }

    private class SeedUser : User
    {
        public string[]? RoleList { get; set; }
    }
}