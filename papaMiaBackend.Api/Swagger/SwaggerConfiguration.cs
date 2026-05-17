using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace papaMiaBackend.Api.Swagger;

internal static class SwaggerConfiguration
{
    private const string PublicDocName = "public";
    private const string AdminDocName = "admin";

    internal static void AddPapaMiaSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(PublicDocName, new OpenApiInfo { Title = "Public API", Version = "v1" });
            c.SwaggerDoc(AdminDocName, new OpenApiInfo { Title = "Admin API", Version = "v1" });

            c.DocInclusionPredicate((docName, api) =>
            {
                var path = api.RelativePath ?? string.Empty;
                var isAdmin = path.StartsWith("api/admin/", StringComparison.OrdinalIgnoreCase);
                return docName switch
                {
                    AdminDocName => isAdmin,
                    PublicDocName => !isAdmin,
                    _ => false
                };
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Access token",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });
            c.OperationFilter<SwaggerBearerOperationFilter>();
        });
    }

    internal static void UsePapaMiaSwagger(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            return;

        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "swagger";
            options.SwaggerEndpoint($"/swagger/{PublicDocName}/swagger.json", "Public API");
            options.SwaggerEndpoint($"/swagger/{AdminDocName}/swagger.json", "Admin API");
        });

        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "swagger/admin";
            options.SwaggerEndpoint($"/swagger/{AdminDocName}/swagger.json", "Admin API");
        });
    }
}
