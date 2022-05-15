using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataPush.Infra.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly ApplicationContext _context;

    public LessonRepository(ApplicationContext context) 
        => _context = context;

    public async Task<Lesson> Get(Guid id)
        => await _context.Set<Lesson>().FirstOrDefaultAsync();

    public async Task<IEnumerable<Lesson>> Get()
        => await _context.Set<Lesson>().ToArrayAsync();

    public void Save(Lesson lesson)
    {
        _context.Add(lesson);
        _context.SaveChanges();
    }

    public void Update(Lesson lesson)
    {
        _context.Update(lesson);
        _context.SaveChanges();
    }
}