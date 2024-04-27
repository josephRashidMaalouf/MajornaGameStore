using MajornaGameStore.DataAccess.Entities;
using MongoDB.Bson;

namespace MajornaGameStore.Shared.Dtos;

public class OrderDto
{
    public string Id { get; set; }
    public string UserId { get; set; } = "Anonymous";
    public ICollection<ProductQuantity> ProductQuantities { get; set; }
    public ICollection<EventQuantity> EventQuantities { get; set; }

    public DateTime DateOfOrder { get; set; }
}