using DataPush.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataPush.Infra.Map
{
    public class LessonMap : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lessons");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Instructor).WithMany(x => x.Lessons).HasForeignKey(x => x.InstructorId);
            builder.HasOne(x => x.Segment).WithMany(x => x.Lessons).HasForeignKey(x => x.SegmentId);
        }
    }
}