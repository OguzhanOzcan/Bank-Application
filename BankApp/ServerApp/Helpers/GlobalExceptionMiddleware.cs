using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ServerApp.Helpers
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                MetricsRegistry.Exceptions.Inc(); 

                context.Response.ContentType = "application/json";

                HttpStatusCode status = HttpStatusCode.InternalServerError;
                string message = "Beklenmeyen bir hata oluştu.";

                if (ex.Message.Contains("Geçersiz miktar") || ex.Message.Contains("Geçersiz vade") || ex.Message.Contains("Yetersiz bakiye"))
                {
                    status = HttpStatusCode.BadRequest;
                    message = ex.Message; 
                }
                else if (ex.Message.Contains("Kullanıcı bakiyesi bulunamadı"))
                {
                    status = HttpStatusCode.NotFound;
                    message = ex.Message;
                }

                context.Response.StatusCode = (int)status;

                var response = new { message };
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }

    }
}
