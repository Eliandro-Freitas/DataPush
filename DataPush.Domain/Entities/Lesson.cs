using System.ComponentModel.DataAnnotations.Schema;

namespace DataPush.Domain.Entities
{
    [Table("Lessons")]
    public class Lesson : BaseEntity
    {
        public Lesson() { }

        public Lesson(string tittle, Guid segmentId, DateTime date, string link, Guid instructorId)
        {
            Tittle = tittle;
            SegmentId = segmentId;
            Date = date;
            Link = link;
            InstructorId = instructorId;
        }

        public string Tittle { get; set; }
        public Guid SegmentId { get; set; }
        public DateTime Date { get; set; }
        public string Link { get; set; }
        public Guid InstructorId { get; set; }

        public Instructor Instructor { get; set; }
        public Segment Segment { get; set; }
    }
}