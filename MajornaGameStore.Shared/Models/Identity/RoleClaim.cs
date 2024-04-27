namespace MajornaGameStore.Shared.Models.Identity;

//TODO: Ta reda på om denna ska vara innuti CookieAuthenticationStateProvider genom partial class?
public class RoleClaim
{
    public string? Issuer { get; set; }
    public string? OriginalIssuer { get; set; }
    public string? Type { get; set; }
    public string? Value { get; set; }
    public string? ValueType { get; set; }
}