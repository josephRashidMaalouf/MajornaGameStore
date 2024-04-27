using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class DeveloperRepository(MajornaDbContext context) : RepositoryBase<Developer, int>(context), IDeveloperRepository
{
    public override async Task<bool> UpdateAsync(Developer entity)
    {
        var developer = await _context.Developers.FindAsync(entity.Id);

        if (developer is null)
            return false;

        developer.Name = entity.Name;
        
        await _context.SaveChangesAsync();
        return false;
    }
    public async Task<Developer?> GetByNameAsync(string name)
    {
        var developer
            = await _context.Developers.FirstOrDefaultAsync(t => t.Name == name);
        if (developer is null)
            return null;

        return developer;
    }
}