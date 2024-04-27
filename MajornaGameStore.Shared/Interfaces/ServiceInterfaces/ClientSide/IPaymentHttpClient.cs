using MajornaGameStore.Shared.CreatePayments;
using MajornaGameStore.Shared.Dtos;

namespace MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

public interface IPaymentHttpClient
{
    Task<string> CreatePayment(CreatePaymentRequest request);
}