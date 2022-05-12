using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataPush.Infra.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationContext _context;

    public CourseRepository(ApplicationContext context)
        => _context = context;

    public async Task<Course> Get(Guid id)
        => await _context.Courses
            .Include(x => x.Segment)
            .FirstOrDefaultAsync(x => id.Equals(x.Id));

    public async Task<IEnumerable<Course>> Get()
        => await _context.Courses
            .Include(x => x.Segment)
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Segment.Name)
            .ToArrayAsync();

    public async Task<IEnumerable<Course>> GetCoursesBySegmentId(Guid id)
        => await _context.Courses
            .Where(x => id.Equals(x.SegmentId))
            .Include(x => x.Segment)
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Segment.Name)
            .ToArrayAsync();

    public void Save(Course course)
    {
        _context.Add(course);
        _context.SaveChanges();
    }
}