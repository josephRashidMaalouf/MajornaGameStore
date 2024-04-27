using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Services;

public class UserService(IUserRepository repository) : ServiceBase<User, string>(repository)
{
    public async Task<List<string>> GetRolesByEmail(string email)
    {
        var roles = await repository.GetRolesByEmail(email);
        return roles;
    }

    public async Task AddRole(string id, string roleName)
    {
        await repository.AddRole(id, roleName);
    }

    public async Task AssignRole(string userId, string roleId)
    {
        await repository.AssignRole(userId, roleId);
    }
}