using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataPush.Infra.Repositories;

public class InstructorRepository : IInstructorRepositor
{
    private readonly ApplicationContext _context;

    public InstructorRepository(ApplicationContext context) 
        => _context = context;

    public void Delete(Instructor instructor)
    {
        _context.Remove(instructor);
        _context.SaveChanges();
    }

    public void Save(Instructor instructor)
    {
        _context.Add(instructor);
        _context.SaveChanges();
    }

    public async Task<Instructor> Get(Guid id)
        => await _context.Set<Instructor>().FirstOrDefaultAsync(x => id.Equals(x.Id));

    public async Task<IEnumerable<Instructor>> Get()
        => await _context.Set<Instructor>().ToArrayAsync();
}