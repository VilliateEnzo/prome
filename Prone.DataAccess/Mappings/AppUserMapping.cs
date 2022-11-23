using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prone.Dal.Models;

namespace Prone.Dal.Mappings;

internal static class AppUserMapping
{
    internal static void Map(ModelBuilder builder)
    {
        EntityTypeBuilder<AppUser> table = builder
            .Entity<AppUser>()
            .ToTable("Users")
            .UseXminAsConcurrencyToken();

        table.HasMany(ur => ur.UserRoles)
            .WithOne(u => u.user)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        table.Property(p => p.CreatedAt)
            .IsRequired();
        
        table.Property(p => p.LastActiveAt)
            .IsRequired();
    }
}