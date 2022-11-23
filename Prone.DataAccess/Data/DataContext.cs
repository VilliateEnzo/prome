using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Prone.Dal.Mappings;
using Prone.Dal.Models;

namespace Prone.Dal.Data;

public class DataContext : IdentityDbContext <AppUser, AppRole, Guid, IdentityUserClaim<Guid>, 
    AppUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
        AppTaskMapping.Map(modelBuilder);
        AppUserMapping.Map(modelBuilder);
        AppUserMapping.Map(modelBuilder);
    }
    
    public DbSet<AppTask> Tasks { get; set; }
    public DbSet<TaskChangeHistory> TaskChanges { get; set; }

}