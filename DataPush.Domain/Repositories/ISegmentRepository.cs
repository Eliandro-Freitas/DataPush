using DataPush.Domain.Entities;

namespace DataPush.Domain.Repositories
{
    public interface ISegmentRepository
    {
        Segment Get(Guid id);
        IEnumerable<Segment> Get();
        void Save(Segment segment);
    }
}