using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;

namespace MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

public interface IUserRepository : IService<User, string>
{
    Task<List<string>> GetRolesByEmail(string email);

    Task AddRole(string id, string role);

    Task AssignRole(string userId, string roleId);
}