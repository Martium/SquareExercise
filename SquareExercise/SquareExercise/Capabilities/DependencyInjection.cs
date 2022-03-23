using Microsoft.Extensions.DependencyInjection;
using SquareExercise.Interface;
using SquareExercise.SqlLiteRepository;

namespace SquareExercise.Capabilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IRepositoryQueryCalls, SqlLiteRepositoryQueryCalls>()
                .AddScoped<IShapeService, PerfectSquareService.PerfectSquareService>();
        }
    }
}
