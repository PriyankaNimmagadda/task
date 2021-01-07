using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MvcSampleApplication.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomeWare
    {
        private readonly RequestDelegate _next;

        public CustomeWare(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.WriteAsync("this is MiddleWare");

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomeWareExtensions
    {
        public static IApplicationBuilder UseCustomeWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomeWare>();
        }
    }
}
