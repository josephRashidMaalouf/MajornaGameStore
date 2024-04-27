using MajornaGameStore.DataAccess.Entities;
using MongoDB.Bson;

namespace MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;

public interface IOrderRepository : IMongoRepositoryBase<Order>
{

}