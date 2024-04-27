using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;
using MongoDB.Bson;

namespace MajornaGameStore.Shared.Mappers;

public static class OrderMapper
{
    public static async Task<OrderDto> MapToDtoAsync(this Order entity)
    {
        
        var dto = new OrderDto
        {
            Id = entity.Id.ToString(),
            UserId = entity.UserId,
            DateOfOrder = entity.DateOfOrder,
            ProductQuantities = entity.ProductQuantities,
            EventQuantities = entity.EventQuantities
        };
        return dto;
    }

    public static Order MapToEntityAsync(this OrderDto dto)
    {
        var entity = new Order
        {
            Id = ObjectId.Parse(dto.Id),
            UserId = dto.UserId,
            DateOfOrder = dto.DateOfOrder,
            ProductQuantities = dto.ProductQuantities,
            EventQuantities = dto.EventQuantities
        };

        return entity;
    }
}