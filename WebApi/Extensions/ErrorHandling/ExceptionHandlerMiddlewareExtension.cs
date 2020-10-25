using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using WebApi.Middlewares;

namespace WebApi.Extensions.ErrorHandling
{
    public static class ExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
