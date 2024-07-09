using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class ProductivAPIDbContext : DbContext
{
    public ProductivAPIDbContext(DbContextOptions<ProductivAPIDbContext> options) : base(options)
    { }

    public DbSet<Goal> Goals { get; set; }
    public DbSet<GoalTask> GoalTasks { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SetUpGoalTaskRelationship(modelBuilder);
        SetupTagGoalsRelationship(modelBuilder);
        SeedGoalsData(modelBuilder);
    }

    private static void SeedGoalsData(ModelBuilder modelBuilder)
    {
        Tag programmingTag = new Tag { Id = Guid.NewGuid(), Name = "Programming" };
        GoalTask taskItem = new GoalTask
        {
            Id = Guid.NewGuid(),
            Name = "Learn C# Basics",
            Description = "Learn the basics of C#",
            CreatedDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(10),
            IsComplete = false,
        };
        Goal goalData = new Goal
        {
            Id = Guid.NewGuid(),
            Name = "Learn C#",
            Description = "Learn C# to build web applications",
            CreatedDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(30),
            IsComplete = false,
            ProgressPercentage = 0,
            GoalTasks = new List<GoalTask> { taskItem },
        };
        modelBuilder.Entity<Goal>().HasData(goalData);
        modelBuilder.Entity<GoalTask>().HasData(taskItem);
        modelBuilder.Entity<Tag>().HasData(programmingTag);
    }

    private static void SetUpGoalTaskRelationship(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Goal>()
            .HasMany(g => g.GoalTasks)
            .WithOne(gt => gt.Goal)
            .HasForeignKey(gt => gt.GoalId);
    }

    private static void SetupTagGoalsRelationship(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>().HasMany(t => t.Goals).WithMany(g => g.Tags);
    }
}
