using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Logging;

namespace MajornaGameStore.DataAccess.Services;

public class EventService(IEventRepository eventRepository) : ServiceBase<Event, int>(eventRepository)
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<ICollection<Event>> GetAllAsync()
    {
        return await _eventRepository.GetAllAsync();
    }

    //TODO:Testa lägg till task delete här
    public async Task<bool> Delete(int eventId)
    {
        var eventExist = await _eventRepository.GetByIdAsync(eventId);
        if (eventExist is null)
        {
            return false;
        }
        return await _eventRepository.DeleteAsync(eventExist.Id);
    }

}