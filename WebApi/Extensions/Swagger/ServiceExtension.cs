using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebApi.Extensions.Swagger
{
    public static class ServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "A simple example ASP.NET Core Web API",

                });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl =
                                new Uri(
                                    $"https://{Application.Auth0Config.Domain}/authorize?audience={System.Web.HttpUtility.UrlEncode(Application.Auth0Config.Audience)}",
                                    UriKind.Absolute)
                        }
                    }
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2",
                            },
                        },
                        Enumerable.Empty<string>().ToList()
                    },
                });
            });
        }
    }
}