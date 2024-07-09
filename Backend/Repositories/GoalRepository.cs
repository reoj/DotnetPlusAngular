using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Controllers;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        public ProductivAPIDbContext Db { get; }

        public GoalRepository(ProductivAPIDbContext db)
        {
            this.Db = db;
        }

        public async Task<Goal> CreateGoal(Goal goal)
        {
            await Db.Goals.AddAsync(goal);
            await Db.SaveChangesAsync();
            return goal;
        }

        public async Task<Goal> DeleteGoal(Guid id)
        {
            var goal = await FindGoalByID(id);
            if (goal is null)
            {
                return null!;
            }

            Db.Goals.Remove(goal);
            await Db.SaveChangesAsync();
            return goal;
        }

        public async Task<Goal> GetGoal(Guid id)
        {
            return await FindGoalByID(id);
        }

        public async Task<List<Goal>> GetGoals()
        {
            return await Db.Goals
                .Include(all => all.GoalTasks)
                .Include(any => any.Tags)
                .ToListAsync();
        }

        public async Task<Goal> UpdateGoal(Goal goal)
        {
            var existingGoal = await FindGoalByID(goal.Id);
            if (existingGoal is null)
            {
                return null!;
            }

            Db.Entry(existingGoal).CurrentValues.SetValues(goal);
            await Db.SaveChangesAsync();
            return existingGoal;
        }

        private async Task<Goal> FindGoalByID(Guid id)
        {
            return await Db.Goals.FindAsync(id)
                ?? throw new KeyNotFoundException($"ID {id} not found.");
        }
    }
}
