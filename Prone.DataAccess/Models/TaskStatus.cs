using Ardalis.SmartEnum;

namespace Prone.Dal.Models;

public class TaskStatus : SmartEnum<TaskStatus, string>
{
    public static readonly TaskStatus TaskCreated = new("TaskCreated");
    public static readonly TaskStatus InProgress = new("InProgress");
    public static readonly TaskStatus Completed = new("Completed");
    public static readonly TaskStatus Abandoned = new("Abandoned");

    public TaskStatus(string name, string value) 
        : base(name, value)
    {
    }

    private TaskStatus(string value) : 
        base(value, value)
    {
    }
}