using AutoMapper;
using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using papaMiaBackend.Api.Auth;
using papaMiaBackend.Api.Swagger;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Mapping;
using papaMiaBackend.DataAccess;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.DataAccess.Seeds;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.Auth;

var envPath = Path.Combine(AppContext.BaseDirectory, ".env");
if (File.Exists(envPath))
{
    Env.Load(envPath);
} else {
    throw new InvalidOperationException("Set .env file");
}

var builder = WebApplication.CreateBuilder(args);

DbSession.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UserContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<ProductContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<LocationContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<BannerContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<PromocodeContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<OrderContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<ArticleContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<IngridientContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<CustomPizzaContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<RoleContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<ReviewContext>(options => options.UseNpgsql(DbSession.ConnectionString));

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.Configure<JwtGenerationSettings>(
    builder.Configuration.GetSection(JwtGenerationSettings.SectionName));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddAdminAccessControl();

var corsOrigins = builder.Configuration.GetSection("Cors:Origins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(corsOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddPapaMiaSwagger();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<UserMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ProductMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<CategoryMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<BannerMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<PromocodeMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<RoleMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AllergenMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<OrderMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<IngridientMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<CustomPizzaMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ReviewMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ArticleMappingProfile>());

builder.Services.AddScoped<BusinessLogicManager>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleDb = scope.ServiceProvider.GetRequiredService<RoleContext>();
    RoleSeed.Apply(roleDb);

    var userDb = scope.ServiceProvider.GetRequiredService<UserContext>();
    var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher<User>>();
    var seedUser = new User();
    var adminPasswordHash = passwordHasher.HashPassword(seedUser, "123");
    AdminUserSeed.Apply(userDb, adminPasswordHash);
}

if (app.Environment.IsDevelopment())
{
    app.UsePapaMiaSwagger();
}

app.UseForwardedHeaders();

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();
app.MapControllers();

app.Run();
