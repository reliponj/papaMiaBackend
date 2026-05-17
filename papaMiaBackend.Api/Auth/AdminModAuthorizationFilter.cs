using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Models.Auth;

namespace papaMiaBackend.Api.Auth;

internal sealed class AdminModAuthorizationFilter : IAsyncActionFilter, IOrderedFilter
{
    public int Order => -10_000;

    private readonly JwtGenerationSettings _jwtSettings;
    private readonly IUserRoleAccessService _accessService;
    private readonly string[] _roleCodes;

    public AdminModAuthorizationFilter(
        IOptions<JwtGenerationSettings> jwtOptions,
        IUserRoleAccessService accessService,
        string[] roleCodes)
    {
        _jwtSettings = jwtOptions.Value;
        _accessService = accessService;
        _roleCodes = (string[])roleCodes.Clone();
    }

    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var userId = BearerAccessTokenResolver.TryGetUserId(context.HttpContext.Request, _jwtSettings);

        if (userId is null)
        {
            context.Result = new UnauthorizedObjectResult(new { message = "unauthorized" });
            return Task.CompletedTask;
        }

        if (!_accessService.UserHasAnyRole(userId.Value, _roleCodes))
        {
            context.Result = new ObjectResult(new { message = "forbidden" })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
            return Task.CompletedTask;
        }

        return next();
    }
}
