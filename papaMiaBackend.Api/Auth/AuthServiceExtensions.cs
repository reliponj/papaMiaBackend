using Microsoft.Extensions.DependencyInjection;
using papaMiaBackend.BusinessLogic.Core;
using papaMiaBackend.BusinessLogic.Interfaces;

namespace papaMiaBackend.Api.Auth;

public static class AuthServiceExtensions
{
    public static IServiceCollection AddAdminAccessControl(this IServiceCollection services)
    {
        services.AddScoped<IUserRoleAccessService, UserRoleAccessService>();
        return services;
    }
}
