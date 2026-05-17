using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using papaMiaBackend.BusinessLogic.Interfaces;
using papaMiaBackend.Domain.Constants;
using papaMiaBackend.Domain.Models.Auth;

namespace papaMiaBackend.Api.Auth;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public sealed class AdminModAttribute : Attribute, IFilterFactory
{
    public bool IsReusable => false;

    private readonly string[] _roleCodes;

    public AdminModAttribute()
    {
        _roleCodes = new[] { RoleCodes.Admin, RoleCodes.Moderator };
    }

    public AdminModAttribute(params string[] roleCodes)
    {
        _roleCodes = roleCodes is { Length: > 0 }
            ? roleCodes
            : new[] { RoleCodes.Admin, RoleCodes.Moderator };
    }

    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
        var jwtOptions = serviceProvider.GetRequiredService<IOptions<JwtGenerationSettings>>();
        var accessService = serviceProvider.GetRequiredService<IUserRoleAccessService>();
        return new AdminModAuthorizationFilter(jwtOptions, accessService, _roleCodes);
    }
}
