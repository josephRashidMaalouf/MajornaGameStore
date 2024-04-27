using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class EventRepository(MajornaDbContext context) : RepositoryBase<Event, int>(context), IEventRepository
{
    private readonly MajornaDbContext _context = context;
    public override async Task<bool> UpdateAsync(Event entity)
    {
        var eventFromDb = await _context.Events.FindAsync(entity.Id);

        if (eventFromDb is null)
            return false;

        eventFromDb.Name = entity.Name;
        eventFromDb.Description = entity.Description;
        eventFromDb.Price = entity.Price;
        eventFromDb.SpotsLeft = entity.SpotsLeft;
        eventFromDb.EventTypeId = entity.EventTypeId;
        eventFromDb.EventStart = entity.EventStart;
        eventFromDb.EventEnd = entity.EventEnd;
        eventFromDb.Users = entity.Users;

        await _context.SaveChangesAsync();
        return true;
    }

   
}