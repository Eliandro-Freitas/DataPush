using System.ComponentModel.DataAnnotations.Schema;

namespace DataPush.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public Lesson() { }

        public Lesson(string tittle, Guid segmentId, DateTime date, string url, Guid instructorId)
        {
            Tittle = tittle;
            SegmentId = segmentId;
            Date = date;
            Url = url;
            InstructorId = instructorId;
        }

        public string Tittle { get; set; }
        public Guid SegmentId { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public Guid InstructorId { get; set; }

        public Instructor Instructor { get; set; }
        public Segment Segment { get; set; }
    }
}