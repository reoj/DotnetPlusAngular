using Backend.Models;
using Microsoft.EntityFrameworkCore;

public class ProductivAPIDbContext : DbContext
{
    public ProductivAPIDbContext(DbContextOptions<ProductivAPIDbContext> options) : base(options)
    { }

    public DbSet<Tag> Tags { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<GoalTask> GoalTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedGoalsData(modelBuilder);
        SetupTagGoalsRelationship(modelBuilder);
        SetUpGoalTaskRelationship(modelBuilder);
    }

    private static void SeedGoalsData(ModelBuilder modelBuilder)
    {
        var FirstGoalId = Guid.NewGuid();
        var FirstGoalTaskId = Guid.NewGuid();
        var FirstTagId = Guid.NewGuid();

        Goal goalData = new Goal
        {
            Id = FirstGoalId,
            Name = "Learn C#",
            Description = "Learn C# to build web applications",
            CreatedDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(30),
            IsComplete = false,
            ProgressPercentage = 0,
        };
        Tag programmingTag = new Tag
        {
            Id = FirstTagId,
            Name = "Programming",
            Goals = new List<Goal> { goalData }
        };

        GoalTask taskItem = new GoalTask
        {
            Id = FirstGoalTaskId,
            Name = "Learn C# Basics",
            Description = "Learn the basics of C#",
            CreatedDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(10),
            IsComplete = false,
            GoalId = FirstGoalId,
            Goal = goalData
        };

        modelBuilder.Entity<Tag>().HasData(programmingTag);
        modelBuilder.Entity<GoalTask>().HasData(taskItem);
        modelBuilder.Entity<Goal>().HasData(goalData);
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
