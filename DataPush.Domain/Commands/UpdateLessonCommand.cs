namespace DataPush.Domain.Commands;

public record UpdateLessonCommand(string Tittle, Guid SegmentId, DateTime Date, string Url)
{
    public Guid Id { get; set; }
}
