using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using MongoDB.Bson;

namespace MajornaGameStore.DataAccess.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    protected const string OrderCollection = "Orders";
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<ICollection<Order>> GetAllAsync()
    {
        return await _orderRepository.GetAllAsync(OrderCollection);
    }

    public async Task<Order?> GetByIdAsync(ObjectId id)
    {
        var order = await _orderRepository.GetByIdAsync(id, OrderCollection);

        if (order is null)
            return null;

        return order;
    }

    public async Task<Order> AddAsync(Order entity)
    {
        var orderReturnedWithId = await _orderRepository.AddAsync(entity, OrderCollection);

        return orderReturnedWithId;
    }

    public async Task<bool> UpdateAsync(Order entity)
    {
        var orderExists =
            await _orderRepository.UpdateAsync(entity, entity.Id, OrderCollection);

        return orderExists;
    }

    public async Task<bool> DeleteAsync(ObjectId id)
    {
        var orderExists =
            await _orderRepository.DeleteAsync(id, OrderCollection);

        return orderExists;
    }
}