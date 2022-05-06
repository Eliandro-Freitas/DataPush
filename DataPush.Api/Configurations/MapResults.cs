using AutoMapper;
using DataPush.Domain.Entities;
using DataPush.Domain.Results;

namespace DataPush.Api.Configurations
{
    public class MapResults : Profile
    {
        public MapResults()
        {
            CourseMap();
            SegmentMap();
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

        private void SegmentMap()
            => CreateMap<Segment, SegmentResult>()
                .ForMember(destination => destination.Id,
                    map => map.MapFrom(source => source.Id))
                .ForMember(destination => destination.Name,
                    map => map.MapFrom(destination => destination.Name));
        }
}