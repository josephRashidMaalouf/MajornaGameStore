using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.Shared.Dtos;

public class EventDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public int SpotsLeft { get; set; } = 50;

    public double Price { get; set; }

    public int TypeId { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }


}
