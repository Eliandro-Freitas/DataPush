using System.ComponentModel.DataAnnotations.Schema;

namespace DataPush.Domain.Entities;

public class Course : BaseEntity
{
    public Course() { }

    public Course(string name, string color, string description, int duration, string difficulty, Guid segmentId) 
    {
        Name = name;
        Color = color;
        Description = description;
        Duration = duration;
        Difficulty = difficulty;
        SegmentId = segmentId;
    }

    public string Name { get; private set; }
    public string Color { get; private init; }
    public string Description { get; private set; }
    public string Difficulty { get; private set; }
    public int Duration { get; private set; }
    public Guid SegmentId { get; private init; }

    public Segment Segment { get; set; }

    public void Update(string name, string description, string difficulty, int duration)
    {
        Name = name;
        Description = description;
        Difficulty = difficulty;
        Duration = duration;
    }
}