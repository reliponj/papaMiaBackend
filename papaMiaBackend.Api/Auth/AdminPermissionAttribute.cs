using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using papaMiaBackend.Domain.Models.Auth;

namespace papaMiaBackend.Api.Auth;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class AdminPermissionAttribute : Attribute, IFilterFactory
{
    public bool IsReusable => false;

    public string Resource { get; }

    public AdminPermissionAttribute(string resource)
    {
        Resource = resource;
    }

    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
        var jwtOptions = serviceProvider.GetRequiredService<IOptions<JwtGenerationSettings>>();
        return new AdminPermissionAuthorizationFilter(jwtOptions, Resource);
    }
}

internal sealed class AdminPermissionAuthorizationFilter : IAsyncActionFilter
{
    private readonly JwtGenerationSettings _jwtSettings;
    private readonly string _resource;

    public AdminPermissionAuthorizationFilter(IOptions<JwtGenerationSettings> jwtOptions, string resource)
    {
        _jwtSettings = jwtOptions.Value;
        _resource = resource;
    }

    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var permissions = BearerAccessTokenResolver.TryGetPermissions(context.HttpContext.Request, _jwtSettings);
        if (permissions is null || permissions.Count == 0)
        {
            context.Result = new UnauthorizedObjectResult(new { message = "unauthorized" });
            return Task.CompletedTask;
        }

        var required = GetPermissionCode(context.HttpContext.Request);
        if (required is null || !permissions.Contains(required))
        {
            context.Result = new ObjectResult(new { message = "forbidden" })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
            return Task.CompletedTask;
        }

        return next();
    }

    private string? GetPermissionCode(HttpRequest request)
    {
        var path = request.Path.Value ?? "";

        if (request.Method == "POST" && (path.Contains("/hide") || path.Contains("/show")))
            return $"{_resource}.update";

        var action = request.Method.ToUpperInvariant() switch
        {
            "GET" or "HEAD" => "view",
            "POST" => "create",
            "PUT" or "PATCH" => "update",
            "DELETE" => "delete",
            _ => null
        };

        return action is null ? null : $"{_resource}.{action}";
    }
}
