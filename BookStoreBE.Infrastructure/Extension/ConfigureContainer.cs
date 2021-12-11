﻿using BookStoreBE.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BookStoreBE.Infrastructure.Extension
{
    public static class ConfigureContainer
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/OpenAPISpecification/swagger.json", "BookStoreBE.WebAPI v1");
                setupAction.RoutePrefix = "OpenAPI";
            });
        }
        public static void ConfigureSwagger(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
        }
    }
}
