using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace dotNET_filtry.Utils
{
    public class CustomFilterAttributes : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {

            var ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            var result = (PageResult)context.Result;
            result.ViewData["IPAddress"] = ipAddress;

            await next.Invoke();
            //base.OnResultExecuting(context);
        }
    }
}
