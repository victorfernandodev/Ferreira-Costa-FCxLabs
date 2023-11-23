using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyName = "api_key";
        private const string ApiKey = "balta_demo_IlTevUM/z0ey3NwCV/unWg==";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Query.TryGetValue(ApiKeyName, out var key))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey não encontrada"
                };

                if (!ApiKey.Equals(key))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 403,
                        Content = "Acesso não autorizado"
                    };
                    return;
                }
            }
            await next();
        }
    }
}
