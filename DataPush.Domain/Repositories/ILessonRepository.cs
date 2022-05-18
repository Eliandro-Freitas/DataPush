using DataPush.Domain.Entities;
using DataPush.Domain.Results;

namespace DataPush.Domain.Repositories;

public interface ILessonRepository
{
    void Save(Lesson lesson);
    void Update(Lesson lesson);
    Task<Lesson> Get(Guid id);
    Task<LessonResult> GetLessonResult(Guid id);
    Task<IEnumerable<LessonResult>> GetLessonsResult();
}