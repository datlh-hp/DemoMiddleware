using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MIS
{
    public class checkurl
    {
        private readonly RequestDelegate _next;

        public checkurl (RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/admin")
            {
                await Task.Run(
                   async () =>
                   {
                       string html = "<h1 style='color: red;'>Khong duoc quyen truy cap</h1>";
                       context.Response.StatusCode = StatusCodes.Status403Forbidden;
                       await context.Response.WriteAsync(html);
                   }
                   );
            }     
            else if(context.Request.Path == "/Human")
            {
                context.Response.Headers.Add("CheckAcessMiddleware", new[] { DateTime.Now.ToString() });
                await _next(context);
            }
            else
            {
                await Task.Run(
                   async () =>
                   {
                       string html = "<h1 style='color: red;'>khong tim thay</h1>";
                       context.Response.StatusCode = StatusCodes.Status404NotFound;
                       await context.Response.WriteAsync(html);
                   }
                   );
            }
        }

    }
}
