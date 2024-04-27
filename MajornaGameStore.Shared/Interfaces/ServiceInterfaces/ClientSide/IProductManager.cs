using MajornaGameStore.Shared.Dtos;

namespace MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

public interface IProductManager
{
    bool ProductsLoaded { get; set; }
    List<ProductDto> Products { get; set; }

    Task LoadProducts();
}