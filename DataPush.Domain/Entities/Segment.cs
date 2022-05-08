using System.ComponentModel.DataAnnotations.Schema;

namespace DataPush.Domain.Entities;

[Table("Segments")]
public class Segment : BaseEntity
{
    private Segment() { }

    public Segment(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public string Name { get; private set; }
    public string Color { get; private set; }

    private readonly List<Course> _courses = new ();
    public IReadOnlyCollection<Course> Courses => _courses;

    private readonly List<Instructor> _instructors = new();
    public IReadOnlyCollection<Instructor> Instructors => _instructors;

    private readonly List<Lesson> _lessons = new();
    public IReadOnlyCollection<Lesson> Lessons => _lessons;
}