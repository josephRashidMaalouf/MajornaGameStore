using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Dtos;

public class CartProductDto : CartItemDto
{
    public int ProductId { get; set; }

}