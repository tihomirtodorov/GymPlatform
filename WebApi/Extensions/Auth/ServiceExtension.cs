using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Utilities;
using WebApi.Utilities.Auth;

namespace WebApi.Extensions.Auth
{
    public static class ServiceExtension
    {
        public static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Constants.ConfigurationConstants.AdminOnly,
                    policy =>
                    {
                        policy.RequireClaim(Application.Auth0Config.RoleClaimType, Application.Auth0Config.AdminRoleName);
                    });
                options.AddPolicy(Constants.ConfigurationConstants.SuperAdmin,
                    policy =>
                    {
                        var permissions = new List<string>() { "create:gyms", "read:gyms", "update:gyms", "delete:gyms" };
                        policy.Requirements = new List<IAuthorizationRequirement>() { new PermissionsRequirement(permissions) };
                    });
            });
        }
    }
}
