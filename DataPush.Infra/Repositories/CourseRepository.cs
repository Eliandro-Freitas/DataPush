using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataPush.Infra.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationContext _context;

    public CourseRepository(ApplicationContext context)
        => _context = context;

    public Course Get(Guid id)
        => _context.Courses
            .Include(x => x.Segment)
            .FirstOrDefault(x => id.Equals(x.Id));

    public IEnumerable<Course> Get()
        => _context.Courses
            .Include(x => x.Segment)
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Segment.Name)
            .ToArray();

    public IEnumerable<Course> GetCoursesBySegmentId(Guid id)
        => _context.Courses
            .Where(x => id.Equals(x.SegmentId))
            .Include(x => x.Segment)
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Segment.Name)
            .ToArray();

    public void Save(Course course)
    {
        _context.Add(course);
        _context.SaveChanges();
    }
}