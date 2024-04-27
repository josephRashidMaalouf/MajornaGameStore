using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class TypeRepository(MajornaDbContext context) 
    : RepositoryBase<ProductType, int>(context), ITypeRepository
{
    public override async Task<bool> UpdateAsync(ProductType entity)
    {
        var type = await _context.ProductTypes.FindAsync(entity.Id);

        if (type is null)
            return false;

        type.Name = entity.Name;
        type.Products = entity.Products;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ProductType?> GetByNameAsync(string name)
    {
        var type = await _context.ProductTypes.FirstOrDefaultAsync(t => t.Name == name);
        if (type is null) 
            return null;

        return type;
    }
}