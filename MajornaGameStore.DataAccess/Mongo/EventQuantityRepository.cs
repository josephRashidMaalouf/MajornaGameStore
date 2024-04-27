using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Mongo;

public class EventQuantityRepository : MongoRepositoryBase<EventQuantity>, IEventQuantityRepository
{
    
}