using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;

namespace MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

public interface IProductRepository : IService<Product, int>
{
    Task<ICollection<Product>> GetByTagIdAsync(int tagId);
}