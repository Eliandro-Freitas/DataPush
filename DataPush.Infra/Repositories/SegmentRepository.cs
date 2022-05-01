using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;

namespace DataPush.Infra.Repositories
{
    public class SegmentRepository : ISegmentRepository
    {
        public readonly ApplicationContext _context;

        public SegmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Segment Get(Guid id)
            => _context.Segments
            .FirstOrDefault(x => id == x.Id);

        public IEnumerable<Segment> Get()
            => _context.Segments.ToArray();

        public void Save(Segment segment) 
        {
            _context.Add(segment);
            _context.SaveChanges();
        }
    }
}