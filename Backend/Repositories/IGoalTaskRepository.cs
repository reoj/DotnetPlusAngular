namespace Backend.Controllers
{
    public interface IGoalTaskRepository
    {
        Task<List<GoalTask>> GetGoalTasks();
        Task<GoalTask> GetGoalTask(Guid id);
        Task<GoalTask> CreateGoalTask(GoalTask goalTask);
        Task<GoalTask> UpdateGoalTask(GoalTask goalTask);
        Task<GoalTask> DeleteGoalTask(Guid id);
    }
}
