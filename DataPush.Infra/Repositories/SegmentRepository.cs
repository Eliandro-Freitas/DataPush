using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataPush.Infra.Repositories;

public class SegmentRepository : ISegmentRepository
{
    public readonly ApplicationContext _context;

    public SegmentRepository(ApplicationContext context)
        => _context = context;

    public async Task<Segment> Get(Guid id)
        => await _context.Segments.FirstOrDefaultAsync(x => id == x.Id);

    public async Task<IEnumerable<Segment>> Get()
        => await _context.Segments.ToArrayAsync();

    public void Save(Segment segment)
    {
        _context.Add(segment);
        _context.SaveChanges();
    }
}