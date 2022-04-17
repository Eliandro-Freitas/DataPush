namespace DataPush.Domain.Entities;

public class Course : BaseEntity
{
    public Course(string name, string color, string description, int duration, Guid segmentId) 
    {
        Name = name;
        Color = color;
        Description = description;
        Duration = duration;
        SegmentId = segmentId;
    }

    public string Name { get; private init; }
    public string Color { get; private init; }
    public string Description { get; private init; }
    public int Duration { get; private init; }
    public Guid SegmentId { get; private init; }

    public Segment Segment { get; set; }
}