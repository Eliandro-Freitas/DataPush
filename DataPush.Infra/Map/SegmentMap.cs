using DataPush.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataPush.Infra.Map
{
    public class SegmentMap : IEntityTypeConfiguration<Segment>
    {
        public void Configure(EntityTypeBuilder<Segment> builder)
        {
            builder.ToTable("Segments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(200);
            builder.Property(x => x.Color).HasColumnType("varchar").HasMaxLength(200);
        }
    }
}