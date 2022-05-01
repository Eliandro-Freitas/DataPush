using AutoMapper;
using DataPush.Domain.Results;
using DataPush.Infra;
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
            return null;
        }
    }
}