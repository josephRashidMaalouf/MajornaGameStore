using MongoDB.Bson;

namespace MajornaGameStore.DataAccess.Entities;

public class EventQuantity : EntityBase<ObjectId>
{
    public int Quantity { get; set; }

    public int EventId { get; set; }

    public int OrderId { get; set; }
}