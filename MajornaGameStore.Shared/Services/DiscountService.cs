using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Services;

public class DiscountService(IDiscountRepository discountRepository) : ServiceBase<Discount, int>(discountRepository)
{
    
}