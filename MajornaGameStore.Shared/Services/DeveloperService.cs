using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;


namespace MajornaGameStore.DataAccess.Services;

public class DeveloperService(IDeveloperRepository repository) : ServiceBase<Developer, int>(repository)
{
    
}