using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace papaMiaBackend.Api.Swagger;

internal sealed class SwaggerBearerOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.ActionDescriptor is not ControllerActionDescriptor action)
            return;

        if (action.MethodInfo.GetCustomAttribute<SwaggerBearerAttribute>(inherit: true) is null
            && action.ControllerTypeInfo.GetCustomAttribute<SwaggerBearerAttribute>(inherit: true) is null)
            return;

        operation.Security =
        [
            new OpenApiSecurityRequirement
            {
                { new OpenApiSecuritySchemeReference("Bearer", context.Document, null), new List<string>() }
            }
        ];
    }
}
