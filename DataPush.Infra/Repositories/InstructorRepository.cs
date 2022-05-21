using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using DataPush.Domain.Results;
using Microsoft.EntityFrameworkCore;

namespace DataPush.Infra.Repositories;

public class InstructorRepository : IInstructorRepository
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
        _context.Set<Instructor>().Add(instructor);
        _context.SaveChanges();
    }

    public async Task<Instructor> Get(Guid id)
        => await _context.Set<Instructor>()
            .FirstOrDefaultAsync(x => id.Equals(x.Id));

    public async Task<IEnumerable<Instructor>> Get()
        => await _context.Set<Instructor>()
            .ToArrayAsync();

    public async Task<InstructorResult> GetInstructorResult(Guid id)
        => await _context.Set<Instructor>()
            .AsNoTrackingWithIdentityResolution()
            .Where(x => id.Equals(x.Id))
            .Select(x => new InstructorResult(x.Id, x.Name, x.Password, x.Segment.Name, x.Segment.Color))
            .FirstOrDefaultAsync();

    public async Task<IEnumerable<InstructorResult>> GetInstructorResults()
        => await _context.Set<Instructor>()
            .AsNoTrackingWithIdentityResolution()
            .Select(x => new InstructorResult(x.Id, x.Name, x.Password, x.Segment.Name, x.Segment.Color))
            .ToArrayAsync();
}