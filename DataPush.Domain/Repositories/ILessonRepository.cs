using DataPush.Domain.Entities;

namespace DataPush.Domain.Repositories;

public interface ILessonRepository
{
    void Save(Lesson lesson);
    void Update(Lesson lesson);
    Task<Lesson> Get(Guid id);
    Task<IEnumerable<Lesson>> Get();
}