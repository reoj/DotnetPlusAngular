using Backend.Models;

public class GoalTask
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsComplete { get; set; }
    public Guid GoalId { get; set; }
    public Goal Goal { get; set; } = null!;
}