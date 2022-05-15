using DataPush.Domain.Commands;
using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataPush.Api.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonController(ILessonRepository lessonRepository) 
            => _lessonRepository = lessonRepository;

        [HttpGet("v1/lessons")]
        public async Task<IActionResult> GetLessons()
            => Ok(await _lessonRepository.Get());

        [HttpGet("v1/lessons/{lessonId:guid}")]
        public async Task<IActionResult> GetLesson(Guid lessonId)
            => Ok(await _lessonRepository.Get(lessonId));

        [HttpPost("v1/lessons")]
        public async Task<IActionResult> PostLesson([FromBody] CreateLessonCommand command)
        {
            var lesson = new Lesson(command.Tittle, command.SegmentId, command.Date, command.Url, command.InstructorId);
            _lessonRepository.Save(lesson);
            return Ok($"Aula salva ({lesson.Id})");
        }

        [HttpPut("v1/lessons/{lessonId:guid}")]
        public async Task<IActionResult> PutLesson(Guid lessonId, [FromBody] UpdateLessonCommand command)
        {
            command.Id = lessonId;
            var lesson = await _lessonRepository.Get(command.Id);
            lesson.Update(command.Tittle, command.SegmentId, command.Date, command.Url);
            _lessonRepository.Update(lesson);
            return Ok($"Aula atualizada ({lesson.Id})");
        }
    }
}
