using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using MongoDB.Bson;
using SharpCompress.Common;

namespace MajornaGameStore.DataAccess.Services;

public class EventQuantityService(IEventQuantityRepository eventQuantityRepository) : IEventQuantityService
{
    protected const string EventQuantityCollection = "EventQuantity";
    private readonly IEventQuantityRepository _eventQuantityRepository = eventQuantityRepository;

    public async Task<ICollection<EventQuantity>> GetAllAsync()
    {
        return await _eventQuantityRepository.GetAllAsync(EventQuantityCollection);
    }

    public async Task<EventQuantity?> GetByIdAsync(ObjectId id)
    {
        var eventQuantity = await _eventQuantityRepository.GetByIdAsync(id, EventQuantityCollection);

        if (eventQuantity is null)
        {
            return null;
        }

        return eventQuantity;
    }


    public async Task<EventQuantity> AddAsync(EventQuantity entity)
    {
        var eventQuantityReturnedWithId = await _eventQuantityRepository.AddAsync(entity, EventQuantityCollection);

        return eventQuantityReturnedWithId;
    }

    public async Task<bool> UpdateAsync(EventQuantity entity)
    {
        var eventQuantityExists =
            await _eventQuantityRepository.UpdateAsync(entity, entity.Id, EventQuantityCollection);

        return eventQuantityExists;
    }

    public async Task<bool> DeleteAsync(ObjectId id)
    {
        var eventQuantityExists =
        await _eventQuantityRepository.DeleteAsync(id, EventQuantityCollection);

        return eventQuantityExists;
    }
}