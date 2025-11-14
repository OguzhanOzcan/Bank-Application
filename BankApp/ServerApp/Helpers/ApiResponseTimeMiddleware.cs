using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ServerApp.Helpers
{
    public class ApiResponseTimeMiddleware
    {
        private readonly RequestDelegate _next;
        public ApiResponseTimeMiddleware(RequestDelegate next){
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();
                var path = context.Request.Path.HasValue ? context.Request.Path.Value : "unknown";
                var method = context.Request.Method;
                var statusCode = context.Response.StatusCode.ToString();

                MetricsRegistry.ApiResponseTime
                    .WithLabels(method, path, statusCode)
                    .Observe(stopwatch.Elapsed.TotalSeconds);
            }
        }
    }
}
