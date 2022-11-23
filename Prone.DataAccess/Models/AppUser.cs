using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Prone.Dal.Models;

public class AppUser : IdentityUser<Guid>
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
        
    public DateTime LastActiveAt { get; set; } = DateTime.Now;
    
    public ICollection<AppUserRole> UserRoles { get; set; }
}