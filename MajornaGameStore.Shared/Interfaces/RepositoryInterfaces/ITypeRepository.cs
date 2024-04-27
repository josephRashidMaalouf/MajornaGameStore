using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;

namespace MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

public interface ITypeRepository : IService<ProductType, int>
{
    Task<ProductType?> GetByNameAsync(string name);
}