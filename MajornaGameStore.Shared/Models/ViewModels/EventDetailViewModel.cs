using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class EventDetailViewModel(IClientEventsService detailService, IClientCartService cartService) : ViewModelBase<EventDto, int>(detailService)
{
    private readonly IClientEventsService _eventDetailService = detailService;
    private readonly IClientCartService _cartService = cartService;

    public EventDto SelectedEvent { get; set; }

    public async Task OnInite(int id)
    {
        SelectedEvent = await _eventDetailService.GetByIdAsync(id);
    }

    public async Task AddToCartAsync(EventDto eventDto, int quantity)
    {
        var cartItems = await cartService.GetAllAsync();
        foreach (var item in cartItems)
        {
            if (item is CartTicketDto)
            {
                CartTicketDto cartTicket = (CartTicketDto)item;

                if (cartTicket.EventId == eventDto.Id)
                {
                    item.Quantity += quantity;
                    eventDto.SpotsLeft--;
                    return;
                }

            }
        }

        var cartItem = new CartTicketDto
        {
            Name = eventDto.Name,
            Price = eventDto.Price,
            EventId = eventDto.Id,
            Quantity = quantity
        };
        await cartService.AddAsync(cartItem);
    }
}