using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private ITagRepository _tagRepository;

        public TagsController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagRepository.GetTags();
            return tags != null ? Ok(tags) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(Guid id)
        {
            var tag = await _tagRepository.GetTag(id);
            return tag != null ? Ok(tag) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] Tag tag)
        {
            var newTag = await _tagRepository.CreateTag(tag);
            return newTag != null ? Ok(newTag) : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag([FromBody] Tag tag)
        {
            var updatedTag = await _tagRepository.UpdateTag(tag);
            return updatedTag != null ? Ok(updatedTag) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            var deletedTag = await _tagRepository.DeleteTag(id);
            return deletedTag != null ? Ok(deletedTag) : NotFound();
        }
    }
}
