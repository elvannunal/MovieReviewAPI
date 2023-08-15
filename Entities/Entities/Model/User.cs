using Microsoft.AspNetCore.Identity;

namespace Entities.Model;

public class User: IdentityUser
{
    public string? FistName { get; set; }
    public string? LastName { get; set; }
    public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();
}