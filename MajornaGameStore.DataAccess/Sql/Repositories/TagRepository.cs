using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class TagRepository(MajornaDbContext context) : RepositoryBase<Tag, int>(context), ITagRepository
{
    public override async Task<bool> UpdateAsync(Tag entity)
    {
        var tag = await _context.Tags.FindAsync(entity.Id);

        if (tag is null)
            return false;

        tag.Name = entity.Name;
        tag.Products = entity.Products;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Tag?> GetByNameAsync(string name)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == name);
        if (tag is null)
            return null;

        return tag;
    }
}
