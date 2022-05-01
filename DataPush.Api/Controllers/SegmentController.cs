using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DataPush.Api.Controllers
{
    public class SegmentController : Controller
    {
        private readonly ISegmentRepository _segmentRepository;

        public SegmentController(ISegmentRepository segmentRepository)
        {
            _segmentRepository = segmentRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("v1/segments")] 
        public ActionResult<Task> GetSegment()
        {
            var segment = new Segment("Tecnologia");
            _segmentRepository.Save(segment);

            var segments = _segmentRepository.Get();
            if (segments is null || !segments.Any()) return BadRequest("Nenhum segmento encontrado");
            return Ok(segments);
        }
    }
}