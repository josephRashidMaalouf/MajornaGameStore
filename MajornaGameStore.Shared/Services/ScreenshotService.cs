using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Services;

public class ScreenshotService(IScreenshotRepository repository) : ServiceBase<Screenshot, int>(repository)
{
    
}