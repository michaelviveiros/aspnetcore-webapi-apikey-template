using Microsoft.AspNetCore.Mvc.Filters;

namespace TemplateWebApiKey.Api.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyName = "ApiSettings:ApiKeyName";
        private const string ApiKeyValue = "ApiSettings:ApiKeyValue";

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}