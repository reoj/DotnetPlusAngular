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
        var FirstGoalId = Guid.Parse("e62ef138-3b54-478f-9b7d-f8fe366844c7");
        var FirstGoalTaskId = Guid.Parse("54ef124d-7529-4bf4-83d4-968dc252cf1b");
        var FirstTagId = Guid.Parse("8b26a8f3-9ab8-4301-82c7-5c213f704c8c");

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
