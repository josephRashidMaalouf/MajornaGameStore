using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.Shared.Interfaces.ServiceInterfaces;

public interface IService<TEntity, TId>
{
    Task<ICollection<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TId id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TId id);


}
