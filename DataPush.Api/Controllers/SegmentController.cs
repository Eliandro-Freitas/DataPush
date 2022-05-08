using AutoMapper;
using DataPush.Domain.Repositories;
using DataPush.Domain.Results;
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

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SegmentResult[]))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("v1/segments")] 
        public ActionResult<Task> GetSegments()
        {
            var segments = _segmentRepository.Get();
            if (segments is null || !segments.Any()) return BadRequest("Nenhum segmento encontrado");

            var segmentsResult = _mapper.Map<IEnumerable<SegmentResult>>(segments);
            return Ok(segmentsResult);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SegmentResult))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("v1/segments/{segmentId:Guid}")]
        public ActionResult<Task> GetSegment(Guid segmentId)
        {
            var segments = _segmentRepository.Get(segmentId);
            if (segments is null) return BadRequest("Segmento não encontrado");

            var segmentsResult = _mapper.Map<SegmentResult>(segments);
            return Ok(segmentsResult);
        }
    }
}