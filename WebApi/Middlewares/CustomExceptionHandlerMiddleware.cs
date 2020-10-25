using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch (exception)
            {
                case EntityException entityException:
                    code = HttpStatusCode.BadRequest;
                    result = entityException.Message;
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = notFoundException.Message;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;

            var serializedResult = JsonSerializer.Serialize(result);

            return context.Response.WriteAsync(serializedResult);
        }
    }
}
