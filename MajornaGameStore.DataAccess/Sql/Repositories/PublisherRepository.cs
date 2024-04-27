using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class PublisherRepository(MajornaDbContext context) : RepositoryBase<Publisher, int>(context), IPublisherRepository
{
    public override async Task<bool> UpdateAsync(Publisher entity)
    {
        var publisher = await _context.Publishers.FindAsync(entity.Id);

        if (publisher is null)
            return false;

        publisher.Name = entity.Name;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Publisher?> GetByNameAsync(string name)
    {
        var publisher = await _context.Publishers.FirstOrDefaultAsync(t => t.Name == name);
        if (publisher is null)
            return null;

        return publisher;
    }

}