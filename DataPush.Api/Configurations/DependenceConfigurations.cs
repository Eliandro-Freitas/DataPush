using DataPush.Domain.Repositories;
using DataPush.Infra.Repositories;

namespace DataPush.Api.Configurations
{
    public static class DependenceConfigurations
    {
        public static void AddDependences(this IServiceCollection service)
        {
            service.AddTransient<ISegmentRepository, SegmentRepository>();
            service.AddTransient<IForumRepository, ForumRepository>();
            service.AddTransient<ICourseRepository, CourseRepository>();
        }
    }
}