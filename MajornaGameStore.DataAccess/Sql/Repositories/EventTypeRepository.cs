using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class EventTypeRepository(MajornaDbContext context) : RepositoryBase<EventType, int>(context), IEventTypeRepository
{
    public override async Task<bool> UpdateAsync(EventType entity)
    {
        var eventTypeFromDb = await _context.EventTypes.FindAsync(entity.Id);

        if (eventTypeFromDb is null)
            return false;

        eventTypeFromDb.Events = entity.Events;
        eventTypeFromDb.Name = entity.Name;

        await _context.SaveChangesAsync();
        return true;
    }
}