using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CustomMiddleware
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = 222;
            context.Response.Headers.Add("Hello", "World");
            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Hello World from Middleware<br>"));

            await _next(context);
        }
    }
}
