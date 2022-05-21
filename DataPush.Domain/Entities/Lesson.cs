namespace DataPush.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public Lesson() { }

        public Lesson(string title, Guid segmentId, DateTime date, string url, Guid instructorId)
        {
            Title = title;
            SegmentId = segmentId;
            Date = date;
            Url = url;
            InstructorId = instructorId;
        }

        public string Title { get; set; }
        public Guid SegmentId { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public Guid InstructorId { get; set; }

        public Instructor Instructor { get; set; }
        public Segment Segment { get; set; }

        public void Update(string title, Guid segmentId, DateTime date, string url)
        {
            Title = title;
            SegmentId = segmentId;
            Date = date;
            Url = url;
        }
    }
}