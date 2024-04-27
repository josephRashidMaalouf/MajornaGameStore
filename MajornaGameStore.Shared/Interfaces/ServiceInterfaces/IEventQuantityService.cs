using MajornaGameStore.DataAccess.Entities;
using MongoDB.Bson;

namespace MajornaGameStore.Shared.Interfaces.ServiceInterfaces;

public interface IEventQuantityService : IService<EventQuantity, ObjectId>
{

}