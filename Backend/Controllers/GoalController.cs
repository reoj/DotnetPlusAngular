using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalController : ControllerBase
    {
        private IGoalRepository _goalRepository;
        private IMapper _mapper;

        public GoalController(IGoalRepository goalRepository, IMapper mapper)
        {
            _goalRepository = goalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetGoals()
        {
            var goals = await _goalRepository.GetGoals();
            return goals != null ? Ok(goals) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGoal(Guid id)
        {
            var goal = await _goalRepository.GetGoal(id);
            return goal != null ? Ok(goal) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGoal([FromBody] Models.Goal goal)
        {
            var newGoal = await _goalRepository.CreateGoal(goal);
            return newGoal != null ? Ok(newGoal) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGoal([FromBody] Models.Goal goal)
        {
            var updatedGoal = await _goalRepository.UpdateGoal(goal);
            return updatedGoal != null ? Ok(updatedGoal) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(Guid id)
        {
            var deletedGoal = await _goalRepository.DeleteGoal(id);
            return deletedGoal != null ? Ok(deletedGoal) : NotFound();
        }
    }
}
