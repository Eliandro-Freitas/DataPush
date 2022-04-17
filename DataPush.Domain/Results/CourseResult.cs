namespace DataPush.Domain.Results
{
    public record CourseResult(
        string Name,
        string Description,
        int Duration,
        string SegmentName,
        Guid SegmentId);
}