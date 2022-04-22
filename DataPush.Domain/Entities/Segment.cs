namespace DataPush.Domain.Entities;

public class Segment : BaseEntity
{
    public Segment(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    private readonly List<Course> _courses = new ();
    public IReadOnlyCollection<Course> Courses => _courses;
}