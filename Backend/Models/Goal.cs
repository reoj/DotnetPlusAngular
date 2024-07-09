using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Goal
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }

        [Range(0, 100)]
        public double ProgressPercentage { get; set; } = 0d;

        [Required]
        public List<GoalTask> GoalTasks { get; set; } = null!;

        public List<Tag> Tags { get; set; } = null!;
    }
}
