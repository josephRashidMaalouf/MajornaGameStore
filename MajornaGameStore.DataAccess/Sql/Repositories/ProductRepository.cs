using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class ProductRepository(MajornaDbContext context) : RepositoryBase<Product, int>(context), IProductRepository
{
    public override async Task<ICollection<Product>> GetAllAsync()
    {
        var products = await _context.Products
            .ToListAsync();

        return products;
    }

    public override async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Screenshots)
            .Include(p => p.Developers)
            .Include(p => p.Publishers)
            .Include(p => p.Reviews)
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<ICollection<Product>> GetByTagIdAsync(int tagId)
    {
        var productsByTag = _context.Products
            .Include(p => p.Screenshots)
            .Include(p => p.Developers)
            .Include(p => p.Publishers)
            .Include(p => p.Reviews)
            .Include(p => p.Tags)
            .Where(p => p.Tags.Any(t => t.Id == tagId));

        return await productsByTag.ToListAsync();
    }


    public override async Task<bool> UpdateAsync(Product entity)
    {
        var product = await _context.Products
            .Include(p => p.Screenshots)
            .Include(p => p.Developers)
            .Include(p => p.Publishers)
            .Include(p => p.Reviews)
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == entity.Id);

        if (product is null)
            return false;

        product.Name = entity.Name;
        product.Price = entity.Price;
        product.ProductTypeId = entity.ProductTypeId;
        product.DiscountId = entity.DiscountId;
        product.Description = entity.Description;
        product.Languages = entity.Languages;
        product.ImageLink = entity.ImageLink;
        product.PcRequirements = entity.PcRequirements;
        product.ReleaseDate = entity.ReleaseDate;
        product.Developers = entity.Developers;
        product.Publishers = entity.Publishers;
        product.Screenshots = entity.Screenshots;
        product.Tags = entity.Tags;
        product.Reviews = entity.Reviews;
        product.AgeRating = entity.AgeRating;

        await _context.SaveChangesAsync();

        return true;
    }
}