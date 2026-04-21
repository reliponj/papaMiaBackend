using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace papaMiaBackend.Api;

internal sealed class SwaggerBearerDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument document, DocumentFilterContext context)
    {
        document.Security ??= new List<OpenApiSecurityRequirement>();
        document.Security.Add(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecuritySchemeReference("Bearer", document, null),
                new List<string>()
            }
        });
    }
}
