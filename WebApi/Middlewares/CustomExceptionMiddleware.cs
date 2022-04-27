using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Middlewares {
    public class CustomExceptionMiddleware {

        private readonly RequestDelegate next;
        private readonly ILoggerService loggerService;
        public CustomExceptionMiddleware (RequestDelegate next, ILoggerService loggerService) {
            this.next = next;
            this.loggerService = loggerService;
        }
        public async Task Invoke (HttpContext context) {
            var watch = Stopwatch.StartNew();
            try {
                string message = "[Request] HTTP" + context.Request.Method + " - " + context.Request.Path;
                loggerService.Write(message);

                await next(context);
                watch.Stop();
                message = "[Response] HTTP" + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + "ms";
                loggerService.Write(message);
            }
            catch (Exception e) {
                watch.Stop();
                await HandleException(context, e, watch);

            }

        }

        private Task HandleException (HttpContext context, Exception e, Stopwatch watch) {


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "[Error] HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + e.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms";
            loggerService.Write(message);



            var result = JsonConvert.SerializeObject(new { error = e.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }
    public static class CustonExceptionMiddlewareExtension {
        public static IApplicationBuilder UseCustomExceptionMiddle (this IApplicationBuilder builder) {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
