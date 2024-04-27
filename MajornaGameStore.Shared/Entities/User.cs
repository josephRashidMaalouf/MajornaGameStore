using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;

namespace MajornaGameStore.DataAccess.Entities;

public class User : IdentityUser
{
    public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
    public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Event> Events { get; set; }
}