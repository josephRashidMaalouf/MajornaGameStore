using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class UserRepository(MajornaDbContext context): RepositoryBase<User, string>(context), IUserRepository
{
    public async Task<List<string>> GetRolesByEmail(string email)
    {

        var userRoleQuery = from user in _context.Users
            join userRoles in _context.UserRoles
                on user.Id equals userRoles.UserId
            join roles in _context.Roles
                on userRoles.RoleId equals roles.Id
            select new { roles };

        var roleNames = new List<string>();

        foreach (var roleQuery in userRoleQuery)
        {
            var name = roleQuery.roles.Name;

            roleNames.Add(name);
        }

        return roleNames;
    }

    public async Task AddRole(string id, string role)
    {
        Role r = new Role();
        r.Id = id;
        r.Name = role;

        await _context.Roles.AddAsync(r);
        await _context.SaveChangesAsync();
    }

    public async Task AssignRole(string userId, string roleId)
    {
        UserRole ur = new UserRole();

        ur.UserId = userId;
        ur.RoleId = roleId;

        await _context.UserRoles.AddAsync(ur);
        await _context.SaveChangesAsync();
    }


    public override Task<bool> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}