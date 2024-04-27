namespace MajornaGameStore.Shared.Models.Identity;

public class UserModel
{
    public string Email { get; set; } = string.Empty;

    public bool IsEmailConfirmed { get; set; }

    public Dictionary<string, string> Claims { get; set; } = [];
}