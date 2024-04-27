using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;

namespace MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

public interface IClientProductService : IService<ProductDto, int>
{
    Task<Product?> GetFullInfoByIdAsync(int id);

}