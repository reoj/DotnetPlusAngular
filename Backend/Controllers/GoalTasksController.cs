using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalTasksController : ControllerBase
    {
        private IGoalTaskRepository _goalTaskRepository;

        public GoalTasksController(IGoalTaskRepository goalTaskRepository)
        {
            _goalTaskRepository = goalTaskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGoalTasks()
        {
            var goalTasks = await _goalTaskRepository.GetGoalTasks();
            return goalTasks != null ? Ok(goalTasks) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGoalTask(Guid id)
        {
            var goalTask = await _goalTaskRepository.GetGoalTask(id);
            return goalTask != null ? Ok(goalTask) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGoalTask([FromBody] GoalTask goalTask)
        {
            var newGoalTask = await _goalTaskRepository.CreateGoalTask(goalTask);
            return newGoalTask != null ? Ok(newGoalTask) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGoalTask([FromBody] GoalTask goalTask)
        {
            var updatedGoalTask = await _goalTaskRepository.UpdateGoalTask(goalTask);
            return updatedGoalTask != null ? Ok(updatedGoalTask) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoalTask(Guid id)
        {
            var deletedGoalTask = await _goalTaskRepository.DeleteGoalTask(id);
            return deletedGoalTask != null ? Ok(deletedGoalTask) : NotFound();
        }
    }
}