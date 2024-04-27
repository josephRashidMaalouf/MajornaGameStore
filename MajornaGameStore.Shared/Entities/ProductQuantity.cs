using MongoDB.Bson;

namespace MajornaGameStore.DataAccess.Entities;

public class ProductQuantity : EntityBase<ObjectId>
{

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }
}