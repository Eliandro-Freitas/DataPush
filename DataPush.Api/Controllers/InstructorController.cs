using DataPush.Domain.Commands;
using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataPush.Api.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _instructorRepositor;

        public InstructorController(IInstructorRepository instructorRepositor) 
            => _instructorRepositor = instructorRepositor;

        [HttpPost("v1/instructors")]
        public IActionResult PostInstructor([FromBody] CreateInstructorCommand command)
        {
            var instructor = new Instructor(command.Name, command.Password, command.SegmentId);
            _instructorRepositor.Save(instructor);
            return Ok($"Professor salvo ({instructor.Id})");
        }

        [HttpGet("v1/instructors")]
        public async Task<IActionResult> GetInstructors()
            => Ok(await _instructorRepositor.GetInstructorResults());

        [HttpGet("v1/instructors/{instructorId:guid}")]
        public async Task<IActionResult> GetInstructor(Guid instructorId)
            => Ok(await _instructorRepositor.GetInstructorResult(instructorId));
    }
}
