using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

namespace MajornaGameStore.DataAccess.Services;

public class TagService(ITagRepository repository) : ServiceBase<Tag, int>(repository)
{
    
}