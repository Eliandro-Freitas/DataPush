using DataPush.Domain.Entities;

namespace DataPush.Domain.Repositories
{
    public interface ISegmentRepository
    {
        void Save(Segment segment);
        Task<Segment> Get(Guid id);
        Task<IEnumerable<Segment>> Get();
    }
}