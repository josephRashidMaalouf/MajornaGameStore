using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;

namespace MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

public interface IMongoRepositoryBase<TEntity>
{
    Task<ICollection<TEntity>> GetAllAsync(string collectionName);
    Task<TEntity?> GetByIdAsync(ObjectId id, string collectionName);
    Task<TEntity> AddAsync(TEntity entity, string collectionName);
    Task<bool> UpdateAsync(TEntity entity, ObjectId id, string collectionName);
    Task<bool> DeleteAsync(ObjectId id, string collectionName);
}