using System.ComponentModel.DataAnnotations;

namespace MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

public interface ICartItem
{
    public string Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string Image { get; set; }
}