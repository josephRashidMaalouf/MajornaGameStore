using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Dtos;

public class CartTicketDto : CartItemDto
{
    public int EventId { get; set; }
}