using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.CreatePayments;


//SKAPA EN betalningssession med produkter i varukorgen
public class CreatePaymentRequest
{
    public List<CartItemDto> Products { get; set; } = new();

    public int Quantity { get; set; }

    public string SuccessRedirectUrl { get; set; }

    public string CancelRedirectUrl { get; set; }
}
