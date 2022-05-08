using DataPush.Domain.Entities;

namespace DataPush.Domain.Repositories;

public interface ICourseRepository
{
    public Course Get(Guid id);
    public IEnumerable<Course> Get();
    public IEnumerable<Course> GetCoursesBySegmentId(Guid id);
    public void Save(Course course);
}