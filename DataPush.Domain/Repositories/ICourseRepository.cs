using DataPush.Domain.Entities;

namespace DataPush.Domain.Repositories;

public interface ICourseRepository
{
    Task<Course> Get(Guid id);
    Task<IEnumerable<Course>> Get();
    Task<IEnumerable<Course>> GetCoursesBySegmentId(Guid id);
    void Save(Course course);
}