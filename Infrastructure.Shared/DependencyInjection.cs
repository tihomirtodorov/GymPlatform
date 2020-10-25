using Application.Interfaces;
using Infrastructure.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Shared
{
    public static class DependencyInjection
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}