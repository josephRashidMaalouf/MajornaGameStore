using MajornaGameStore.Shared.Models.Identity;

namespace MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

public interface IAccountManagement
{
    public Task<AuthResponseModel> LoginAsync(string email, string password);

    public Task LogoutAsync();

    public Task<AuthResponseModel> RegisterAsync(string email, string password);

    public Task<bool> CheckAuthenticatedAsync();

    Task<bool> IsAdmin();
}