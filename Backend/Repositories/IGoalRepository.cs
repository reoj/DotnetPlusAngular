using Backend.Models;

namespace Backend.Controllers
{
    public interface IGoalRepository
    {
        Task<List<Goal>> GetGoals();
        Task<Goal> GetGoal(Guid id);
        Task<Goal> CreateGoal(Goal goal);
        Task<Goal> UpdateGoal(Goal goal);
        Task<Goal> DeleteGoal(Guid id);
    }
}