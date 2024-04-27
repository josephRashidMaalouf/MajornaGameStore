using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;

namespace MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

public interface ITagRepository : IService<Tag, int>
{
    Task<Tag?> GetByNameAsync(string name);
}