using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using MongoDB.Bson;

namespace MajornaGameStore.DataAccess.Services;

public class ProductQuantityService(IProductQuantityRepository productQuantityRepository) : IProductQuantityService
{
    protected const string ProductQuantityCollection = "ProductQuantity";
    protected readonly IProductQuantityRepository _productQuantityRepository = productQuantityRepository;

    public async Task<ICollection<ProductQuantity>> GetAllAsync()
    {
        return await _productQuantityRepository.GetAllAsync(ProductQuantityCollection);
    }

    public async Task<ProductQuantity?> GetByIdAsync(ObjectId id)
    {
        var productQuantity = await _productQuantityRepository.GetByIdAsync(id, ProductQuantityCollection);

        if (productQuantity is null)
        {
            return null;
        }

        return productQuantity;
    }

    public async Task<ProductQuantity> AddAsync(ProductQuantity entity)
    {
        var productQuantityReturnedWithId = await _productQuantityRepository.AddAsync(entity, ProductQuantityCollection);

        return productQuantityReturnedWithId;
    }

    public async Task<bool> UpdateAsync(ProductQuantity entity)
    {
        var productQuantityExists =
            await _productQuantityRepository.UpdateAsync(entity, entity.Id, ProductQuantityCollection);

        return productQuantityExists;
    }

    public async Task<bool> DeleteAsync(ObjectId id)
    {
        var productQuantityExists =
            await _productQuantityRepository.DeleteAsync(id, ProductQuantityCollection);

        return productQuantityExists;
    }
}