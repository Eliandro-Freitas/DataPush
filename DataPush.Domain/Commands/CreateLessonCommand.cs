namespace DataPush.Domain.Commands;

public record CreateLessonCommand(string Tittle, Guid SegmentId, DateTime Date, string Url, Guid InstructorId);