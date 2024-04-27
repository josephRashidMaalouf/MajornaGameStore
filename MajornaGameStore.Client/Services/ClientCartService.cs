using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Services;

public class ClientCartService : IClientCartService
{

    public List<CartItemDto> Cart { get; set; } = new();

    //TODO: Update this service in sprint 2. IdGenerator will not be needed
    public string IdGenerator { get; set; } = string.Empty;
    public async Task<ICollection<CartItemDto>> GetAllAsync()
    {
        return Cart.ToList();
    }

    public Task<CartItemDto?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<CartItemDto> AddAsync(CartItemDto entity)
    {
        var r = new Random();
        var randomId = string.Empty;

        for (int i = 0; i < 10; i++)
        {
            var randomNumber = r.Next(9);
            randomId += randomNumber.ToString();
        }
        entity.Id = randomId;
        Cart.Add(entity);
        return entity;
    }

    public Task<bool> UpdateAsync(CartItemDto entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var product = Cart.FirstOrDefault(o => o.Id == id);

        Cart.Remove(product);

        return true;
    }
}