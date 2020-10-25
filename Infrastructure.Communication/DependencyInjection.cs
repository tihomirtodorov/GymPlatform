using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces.Apis;
using Application.Interfaces.Repositories;
using Infrastructure.Communication.Apis.JsonPlaceholder;
using Infrastructure.Communication.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Communication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommunicationInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IJsonPlaceholderApi, JsonPlaceholderApiBase>();
            return services;
        }
    }
}
