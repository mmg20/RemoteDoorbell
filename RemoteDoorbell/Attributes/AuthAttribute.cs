using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace RemoteDoorbell.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Token", out var headerToken))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var token = config.GetValue<string>("Secret");

            if (!token.Equals(headerToken))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}