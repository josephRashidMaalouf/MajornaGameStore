using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class DiscountRepository(MajornaDbContext context) : RepositoryBase<Discount, int>(context), IDiscountRepository
{
    public override async Task<ICollection<Discount>> GetAllAsync()
    {
        var discounts = _context.Discounts
            .Include(d => d.Products);

        return await discounts.ToListAsync();
    }

    public override async Task<bool> UpdateAsync(Discount entity)
    {
        var discount = await _context.Discounts.FindAsync(entity.Id);

        if (discount is null)
            return false;

        discount.DiscountPercentage = entity.DiscountPercentage;
        discount.Products = entity.Products;
        discount.DiscountStart = entity.DiscountStart;
        discount.DiscountEnd = entity.DiscountEnd;

        await _context.SaveChangesAsync();
        return true;
    }
}