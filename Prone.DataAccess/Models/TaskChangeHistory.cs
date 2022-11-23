namespace Prone.Dal.Models;

public class TaskChangeHistory
{
    public Guid Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public AppUser AppUser { get; set; }
    
    public Guid AppUserId { get; set; }
    
    public string ChangeDescription { get; set; }
    
    public bool Completed { get; set; }
}