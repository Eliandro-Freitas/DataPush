using AutoMapper;
using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataPush.Api.Controllers
{
    public class SegmentController : Controller
    {
        private readonly ISegmentRepository _segmentRepository;
        private readonly IMapper _mapper;

        public SegmentController(ISegmentRepository segmentRepository, IMapper mapper)
        {
            _segmentRepository = segmentRepository;
            _mapper = mapper;
        }

        [HttpGet("v1/segments")] 
        public ActionResult<Task> GetSegment()
        {
            var segments = _segmentRepository.Get();
            if (segments is null || !segments.Any()) return BadRequest("Nenhum segmento encontrado");
            var segmentsResult = _mapper.Map<IEnumerable<Segment>>(segments);
            return Ok(segmentsResult);
        }
    }
}