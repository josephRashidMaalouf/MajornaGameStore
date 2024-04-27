using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Services;

public class PublisherService(IPublisherRepository repository) : ServiceBase<Publisher, int>(repository)
{
    
}