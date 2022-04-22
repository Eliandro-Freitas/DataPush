using DataPush.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataPush.Infra.Map
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        private readonly EntityTypeBuilder<Course> _builder;

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            ConfigureProperties();
            builder.ToTable("Courses");
            builder.HasOne(x => x.Segment).WithMany(x => x.Courses).HasForeignKey(x => x.SegmentId);
        }

        private void ConfigureProperties()
        {
            _builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(500);
            _builder.Property(x => x.Color).HasColumnType("varchar").HasMaxLength(100);
            _builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(200);
        }
    }
}