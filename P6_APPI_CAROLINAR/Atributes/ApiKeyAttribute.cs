using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace P6_APPI_CAROLINAR.Attributes
{

    [AttributeUsage(validOn: AttributeTargets.All)]
    public sealed class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {

        private readonly string _apiKey = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Headers.TryGetValue(_apiKey, out var ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Llamada a API no contiene información de seguridad"
                };
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var ApiKeyValue = appSettings.GetValue<string>(_apiKey);

            if (ApiKeyValue != null && !ApiKeyValue.Equals(ApiSalida))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "El valor de llave de seguridad es incorrecto"
                };
                return;
            }

            await next();  
        
        }

    }
}
 