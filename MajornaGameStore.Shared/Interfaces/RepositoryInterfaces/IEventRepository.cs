using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;

namespace MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

public interface IEventRepository : IService<Event, int>
{

}