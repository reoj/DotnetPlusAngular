using Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class GoalTask
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsComplete { get; set; }

    [ForeignKey("Goal")]
    public Guid GoalId { get; set; }
    public Goal Goal { get; set; } = null!;
}
