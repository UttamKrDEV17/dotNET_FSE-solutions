using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiHandson.Filters
{
    public class CustomAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if the action or controller has AllowAnonymous attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata
                .Any(em => em.GetType() == typeof(AllowAnonymousAttribute));

            if (allowAnonymous)
            {
                base.OnActionExecuting(context);
                return;
            }

            // Check if Authorization header exists
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
                return;
            }

            // Get Authorization header value
            var authHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            
            // Check if header contains "Bearer"
            if (!authHeader.Contains("Bearer"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
