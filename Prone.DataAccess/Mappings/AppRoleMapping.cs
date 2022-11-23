using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prone.Dal.Models;

namespace Prone.Dal.Mappings;

internal static class AppRoleMapping
{
    internal static void Map(ModelBuilder builder)
    {
        EntityTypeBuilder<AppRole> table = builder
            .Entity<AppRole>()
            .ToTable("Roles")
            .UseXminAsConcurrencyToken();

        table.HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
    }
}