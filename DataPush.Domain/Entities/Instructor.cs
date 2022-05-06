using System.ComponentModel.DataAnnotations.Schema;

namespace DataPush.Domain.Entities;

public class Instructor : BaseEntity
{
    public Instructor() { }

    public Instructor(int name, int password, Guid segmentId)
    {
        Name = name;
        Password = password;
        SegmentId = segmentId;
    }

    public int Name { get; set; }
    public int Password { get; set; }
    public Guid SegmentId { get; set; }

    public Segment Segment { get; set; }

    private readonly List<Lesson> _lessons = new();
    public IReadOnlyCollection<Lesson> Lessons => _lessons;
}