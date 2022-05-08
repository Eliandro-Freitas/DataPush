using AutoMapper;
using DataPush.Domain.Repositories;
using DataPush.Domain.Results;
using Microsoft.AspNetCore.Mvc;

namespace DataPush.Api.Controllers
{
    public class CourseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public CourseController(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseResult[]))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("v1/courses")]
        public ActionResult<Task> GetCourses()
        {
            var courses = _courseRepository.Get();
            if (courses is null || !courses.Any()) return NotFound("Nenhum Curso encontrado");

            var coursesResult = _mapper.Map<IEnumerable<CourseResult>>(courses);
            return Ok(coursesResult);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseResult))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("v1/courses/{courseId:Guid}")]
        public ActionResult<Task> GetCourse(Guid courseId)
        {
            var courses = _courseRepository.Get(courseId);
            if (courses is null) return NotFound($"Curso não encontrado ({courseId})");

            var coursesResult = _mapper.Map<CourseResult>(courses);
            return Ok(coursesResult);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseResult))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("v1/courses/segments/{segmentId:Guid}")]
        public ActionResult<Task> GetCoursesBySegmentId(Guid segmentId)
        {
            var courses = _courseRepository.GetCoursesBySegmentId(segmentId);
            if (courses is null) return NotFound("Nenhum Curso encontrado");

            var coursesResult = _mapper.Map<IEnumerable<CourseResult>>(courses);
            return Ok(coursesResult);
        }
    }
}