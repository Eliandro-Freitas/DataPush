using DataPush.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataPush.Infra.Map
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Segment).WithMany(x => x.Courses).HasForeignKey(x => x.SegmentId);

            ConfigurePoperties(builder);
        }

        private static void ConfigurePoperties(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(500);
            builder.Property(x => x.Color).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Difficulty).HasColumnType("varchar").HasMaxLength(100);
        }
    }
}