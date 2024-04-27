using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Services;

public class ProductTypeService(ITypeRepository typeRepository) : ServiceBase<ProductType, int>(typeRepository)
{
    
}