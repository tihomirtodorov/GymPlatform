using Microsoft.AspNetCore.Builder;

namespace WebApi.Extensions.Swagger
{
    public static class AppExtension
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.OAuthClientId(Application.Auth0Config.ClientId);
            });
        }
    }
}
