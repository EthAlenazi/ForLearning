﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConventionalMiddleware
    {
        private readonly RequestDelegate _next;

        public ConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("Data"))
                httpContext.Response.WriteAsync("\n in this case the url must have contain Data Key ");


            return _next(httpContext);
            // the reponce will be 
            //Atheer .... @ grate @Alenazi.... @ grate @
            // in this case the url must have contain Data Key

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ConventionalMiddlewareExtensions
    {
        public static IApplicationBuilder UseConventionalMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConventionalMiddleware>();
        }
    }
}
