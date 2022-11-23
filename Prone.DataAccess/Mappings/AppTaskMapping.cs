using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prone.Dal.Models;
using TaskStatus = Prone.Dal.Models.TaskStatus;

namespace Prone.Dal.Mappings;

public class AppTaskMapping
{
    internal static void Map(ModelBuilder builder)
    {
        EntityTypeBuilder<AppTask> table = builder
            .Entity<AppTask>()
            .ToTable("Tasks")
            .UseXminAsConcurrencyToken();

        table.HasKey(p => p.Id);
        table.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        table.Property(p => p.title)
            .IsRequired()
            .HasMaxLength(100);

        table.Property(p => p.Description)
            .IsRequired(false)
            .HasMaxLength(Int32.MaxValue);

        table.Property(p => p.Updated).IsRequired();
        table.Property(p => p.Created).IsRequired();

        table.Property(p => p.Statuses)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasConversion(to => to.Select(p => p.Value),
                from => new HashSet<TaskStatus>(
                    from.Select(p => TaskStatus.FromName(p, true))));
        
        table.Property(p => p.IsCompleted).IsRequired();

        table.Property(p => p.IsDeleted).IsRequired();
        table.HasQueryFilter(p => !p.IsDeleted);
        
        table.Property(p => p.IsInactive).IsRequired();
        
        table.Property(p => p.Created).IsRequired();
        table.Property(p => p.Updated).IsRequired();
    }
}