namespace DataPush.Domain.Entities;

public class Instructor : BaseEntity
{
    public string Document { get; private init; }
    public int Age { get; private init; }
}