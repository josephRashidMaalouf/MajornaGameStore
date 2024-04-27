using Microsoft.AspNetCore.Identity;

namespace MajornaGameStore.DataAccess.Entities;

public class Role : IdentityRole
{
    public Role() { }

    public Role(string roleName) : base(roleName) { }
    public virtual ICollection<UserRole> UserRoles { get; set; }
}