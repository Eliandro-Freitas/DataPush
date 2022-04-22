using AutoMapper;
using DataPush.Domain.Entities;
using DataPush.Domain.Results;

namespace DataPush.Api.Configurations
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CourseMap();
        }

        private void CourseMap() 
            => CreateMap<Course, CourseResult>()
                .ForMember(destination => destination.Description,
                    map => map.MapFrom(source => source.Description))
                .ForMember(destination => destination.Name,
                    map => map.MapFrom(source => source.Name))
                .ForMember(destination => destination.Duration,
                    map => map.MapFrom(source => source.Duration))
                .ForMember(destination => destination.SegmentId,
                    map => map.MapFrom(source => source.SegmentId))
                .ForMember(destination => destination.SegmentName,
                    map => map.MapFrom(source => source.Segment.Name));
    }
}