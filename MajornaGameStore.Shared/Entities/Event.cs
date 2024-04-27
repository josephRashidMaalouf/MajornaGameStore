namespace MajornaGameStore.DataAccess.Entities;

public class Event : EntityBase<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int SpotsLeft { get; set; } = 50;
    public int EventTypeId { get; set; } = 1;
    public DateTime EventStart { get; set; }
    public DateTime EventEnd { get; set; }
    public ICollection<User> Users { get; set; }
}