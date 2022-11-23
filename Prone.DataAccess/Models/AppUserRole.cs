using Microsoft.AspNetCore.Identity;

namespace Prone.Dal.Models;

public class AppUserRole : IdentityUserRole<Guid>
{
    public AppUser user { get; set; }
    
    public AppRole Role { get; set; }
}