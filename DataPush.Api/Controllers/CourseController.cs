using AutoMapper;
using DataPush.Domain.Entities;
using DataPush.Domain.Results;
using Microsoft.AspNetCore.Mvc;

namespace DataPush.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;

        public CourseController(ILogger<CourseController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<CourseResult> Get()
        {
            var courses = Enumerable.Range(1, 5).Select(index => new Course(
                "Eliandro",
                "cor",
                "descricao",
                100,
                Guid.NewGuid()
            ))
            .ToArray();

            var courseResult = _mapper.Map<IEnumerable<CourseResult>>(courses);
            return courseResult;
        }
    }
}