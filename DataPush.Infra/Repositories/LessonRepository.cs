using DataPush.Domain.Entities;
using DataPush.Domain.Repositories;
using DataPush.Domain.Results;
using Microsoft.EntityFrameworkCore;

namespace DataPush.Infra.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly ApplicationContext _context;

    public LessonRepository(ApplicationContext context)
        => _context = context;

    public async Task<LessonResult> GetLessonResult(Guid id)
        => await
            (from lesson in _context.Set<Lesson>().AsNoTrackingWithIdentityResolution()
             join segment in _context.Set<Segment>() on lesson.SegmentId equals segment.Id
             join instructor in _context.Set<Instructor>() on lesson.InstructorId equals instructor.Id
             where id.Equals(lesson.Id)
             select new LessonResult(
                 lesson.Tittle,
                 lesson.Date,
                 lesson.Url,
                 instructor.Name)
             {
                 Segment = new LessonResult.SegmentResult(segment.Name, segment.Color)
             })
            .FirstOrDefaultAsync();

    public async Task<IEnumerable<LessonResult>> GetLessonsResult()
        => await
            (from lesson in _context.Set<Lesson>().AsNoTrackingWithIdentityResolution()
             join segment in _context.Set<Segment>() on lesson.SegmentId equals segment.Id
             join instructor in _context.Set<Instructor>() on lesson.InstructorId equals instructor.Id
             select new LessonResult(
                 lesson.Tittle,
                 lesson.Date,
                 lesson.Url,
                 instructor.Name)
             {
                 Segment = new LessonResult.SegmentResult(segment.Name, segment.Color)
             })
            .ToArrayAsync();

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

    public async Task<Lesson> Get(Guid id)
        => await _context.Set<Lesson>().FirstOrDefaultAsync(x => id.Equals(x.Id));
}