namespace MajornaGameStore.DataAccess.Entities;

public class EventType : EntityBase<int>
{
    public string Name { get; set; }

    public ICollection<Event> Events { get; set; }

}