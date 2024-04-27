using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Services;

public class EventTypeService(IEventTypeRepository repository) : ServiceBase<EventType, int>(repository)
{
    
}