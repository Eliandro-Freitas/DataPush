namespace DataPush.Domain.Results
{
    public record CourseResult(
        Guid Id,
        string Name,
        string Description,
        int Duration,
        Guid SegmentId,
        string SegmentColor,
        string SegmentName);
}