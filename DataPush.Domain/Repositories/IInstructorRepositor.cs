using DataPush.Domain.Entities;

namespace DataPush.Domain.Repositories;

public interface IInstructorRepositor
{
    void Save(Instructor instructor);
    void Delete(Instructor instructor);
    Task<Instructor> Get(Guid id);
    Task<IEnumerable<Instructor>> Get();
}