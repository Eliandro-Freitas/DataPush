namespace DataPush.Domain.Results
{
    public record LessonResult(string Title, DateTime Date, string Url, string InstructorName)
    {
        public SegmentResult Segment { get; set; }

        public record SegmentResult(string Name, string Color);
    }
}