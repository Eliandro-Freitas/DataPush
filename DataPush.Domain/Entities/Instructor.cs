namespace DataPush.Domain.Entities;

public class Instructor : BaseEntity
{
    public Instructor() { }

    public Instructor(string name, string password, Guid segmentId)
    {
        Name = name;
        Password = password;
        SegmentId = segmentId;
    }

    public string Name { get; set; }
    public string Password { get; set; }
    public Guid SegmentId { get; set; }

    public Segment Segment { get; set; }

    private readonly List<Lesson> _lessons = new();
    public IReadOnlyCollection<Lesson> Lessons => _lessons;
}