using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WordCount.WebApi.Middleware
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {

            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                //on any exception return error to client
                //this part can be customized
                string sResult = ex.Message;
                context.Response.Headers["Content-Encoding"] = "UTF-8";
                context.Response.ContentType = "text/json";
                await context.Response.WriteAsync(sResult);
            }
        }

    }
}
