using DataPush.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataPush.Infra.Map
{
    public class InstructorMap : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");
            builder.HasKey(x => x.Id);
        }
    }
}