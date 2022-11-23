namespace Prone.Dal.Models;

public class AppTask
{
    public Guid Id { get; set; }
    
    public string title { get; set; }

    public string Description { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public bool IsInactive { get; set; }
    
    public bool IsDeleted { get; set; }

    public HashSet<TaskStatus> Statuses { get; set; } = new();
    
    public DateTime Created { get; set; } = DateTime.Now;
    
    public DateTime Updated { get; set; } = DateTime.Now;

    public List<TaskChangeHistory> ChangesHistory { get; set; } = new();
    
    public AppUser AppUser { get; set; }
    
    public Guid AppUserId { get; set; }
}