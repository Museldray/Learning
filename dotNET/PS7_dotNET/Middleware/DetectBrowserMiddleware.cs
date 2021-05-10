using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Shyjus.BrowserDetection;

namespace PS7_dotNET.Middleware
{
    public class DetectBrowserMiddleware
    {
        private readonly RequestDelegate _next;

        public DetectBrowserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IBrowserDetector detector)
        {
            //var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
            var browser = detector.Browser;

            if(browser.Name == BrowserNames.Edge)
            {
                await httpContext.Response.WriteAsync("Przegladarka nie jest obslugiwana!");
            }
            else if(browser.Name == BrowserNames.EdgeChromium)
            {
                await httpContext.Response.WriteAsync("Przegladarka nie jest obslugiwana!");
            }
            else if(browser.Name == BrowserNames.InternetExplorer)
            {
                await httpContext.Response.WriteAsync("Przegladarka nie jest obslugiwana!");
            }
            else
            {
                await this._next.Invoke(httpContext);
            }
        }
    }
    
    public static class BrowserMiddlewareExtensions
    {
        public static IApplicationBuilder UseBrowserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DetectBrowserMiddleware>();
        }
    }
    
}
