namespace DataPush.Domain.Commands;

public record CreateInstructorCommand(string Name, string Password, Guid SegmentId);