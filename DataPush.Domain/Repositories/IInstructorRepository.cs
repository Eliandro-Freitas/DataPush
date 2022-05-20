using DataPush.Domain.Entities;
using DataPush.Domain.Results;

namespace DataPush.Domain.Repositories;

public interface IInstructorRepository
{
    void Save(Instructor instructor);
    void Delete(Instructor instructor);
    Task<Instructor> Get(Guid id);
    Task<IEnumerable<Instructor>> Get();
    Task<InstructorResult> GetInstructorResult(Guid id);
    Task<IEnumerable<InstructorResult>> GetInstructorResults();
}