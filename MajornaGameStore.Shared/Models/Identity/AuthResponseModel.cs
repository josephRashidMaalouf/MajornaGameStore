namespace MajornaGameStore.Shared.Models.Identity;

public class AuthResponseModel
{
    public bool Succeeded { get; set; }
    public string[] ErrorList { get; set; } = [];
}