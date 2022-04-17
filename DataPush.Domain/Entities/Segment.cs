namespace DataPush.Domain.Entities;

public class Segment : BaseEntity
{
    public Segment(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}