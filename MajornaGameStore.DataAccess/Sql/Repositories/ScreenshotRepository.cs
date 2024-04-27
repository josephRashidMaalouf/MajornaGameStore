using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class ScreenshotRepository(MajornaDbContext context) : RepositoryBase<Screenshot, int>(context), IScreenshotRepository
{
    public override async Task<bool> UpdateAsync(Screenshot entity)
    {
        var screenshot = await _context.Screenshots.FindAsync(entity.Id);

        if (screenshot is null)
            return false;

        screenshot.Path = entity.Path;

        await _context.SaveChangesAsync();
        return true;
    }
}